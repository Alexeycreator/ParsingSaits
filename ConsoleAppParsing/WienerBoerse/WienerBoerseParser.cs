﻿using System.Collections.Generic;
using System.Net.Http;
using HtmlAgilityPack;
using System.Linq;
using System;
using NLog;

namespace ConsoleAppParsing
{
	class WienerBoerseParser
	{
		private string _wienerBoerseUrl;
		private readonly string _webServiceUrl = $"https://localhost:44352/api/File/upload";
		private readonly HttpClient _httpClient = new HttpClient();
		private readonly HttpResponseMessage _httpResponseMessage = new HttpResponseMessage();
		private static Logger bondsLogger = LogManager.GetCurrentClassLogger();
		private int numberPage = 1;
		private static string dateGetBonds = DateTime.Now.ToShortDateString();
		private readonly string CSVFilePath = $@"C:\Users\Алексей\Desktop\Учеба\github\ParsingSaits\ConsoleAppParsing\bin\Debug\parsingBonds\Bonds_{dateGetBonds}.csv";
		private CsvWriter _csvWriter = new CsvWriter();
		private FileSender _fileSender = new FileSender();
		private int _countColumnsSaits = 9;
		private readonly string _type = "wb";
		public string GetBonds()
		{
			List<Bond> bonds = new List<Bond>();
			do
			{
				string urlWienerBoerse = $"https://www.wienerborse.at/en/bonds/?c7928-page={numberPage}&per-page=50&c";
				_wienerBoerseUrl = urlWienerBoerse;
				bondsLogger.Info($"Подключение к странице сайта по адресу: {_wienerBoerseUrl}");
				var _httpResponseMessage = _httpClient.GetAsync(_wienerBoerseUrl).Result;
				if (_httpResponseMessage.IsSuccessStatusCode)
				{
					bondsLogger.Info($"Подключение прошло успешно. {_httpResponseMessage.StatusCode}");
					var _htmlResponse = _httpResponseMessage.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrEmpty(_htmlResponse))
					{
						HtmlDocument document = new HtmlDocument();
						document.LoadHtml(_htmlResponse);
						var container = document.GetElementbyId("c7928-module-container");
						if (container != null)
						{
							var tableBody = document.GetElementbyId("c7928-module-container").ChildNodes.FindFirst("tbody").ChildNodes.Where(x => x.Name == "tr").ToArray();
							bondsLogger.Info($"Контент страницы №{numberPage} получен.");
							bondsLogger.Info("Извлечение данных.");
							var _countCells = document.GetElementbyId("c7928-module-container").ChildNodes.FindFirst("tbody").SelectSingleNode(".//tr").ChildNodes.Count;
							try
							{
								if (_countCells == _countColumnsSaits)
								{
									foreach (var tableRow in tableBody)
									{
										var _cellName = tableRow.ChildNodes.FindFirst("td").ChildNodes.FindFirst("a").InnerText;
										var _cellLast = tableRow.SelectSingleNode(".//td[2]").InnerText;
										var _cellChg = tableRow.SelectSingleNode(".//td[3]").InnerText;
										var _cellDate = tableRow.SelectSingleNode(".//td[4]").InnerText;
										var _cellISin = tableRow.SelectSingleNode(".//td[5]").InnerText;
										//var _cellTurnoverVolume = tableRow.SelectSingleNode(".//td[6]").InnerText;
										var _cellBidVolume = tableRow.SelectSingleNode(".//td[6]").InnerText;
										var _cellAskVolume = tableRow.SelectSingleNode(".//td[7]").InnerText;
										var _cellMaturity = tableRow.SelectSingleNode(".//td[8]").InnerText;
										var _cellStatus = tableRow.SelectSingleNode(".//td[9]").InnerText;
										bonds.Add(new Bond
										{
											Name = _cellName,
											Last = _cellLast,
											Chg = _cellChg,
											Date = _cellDate,
											ISin = _cellISin,
											//TurnoverVolume = _cellTurnoverVolume,
											BidVolume = _cellBidVolume,
											AskVolume = _cellAskVolume,
											Maturity = _cellMaturity,
											Status = _cellStatus
										});
									}
									if (bonds != null && _countCells == _countColumnsSaits)
									{
										bondsLogger.Info($"Данные со страницы №{numberPage} извлечены. Количество: {bonds.Count}");
									}
									else
									{
										bondsLogger.Error($"Данные со страницы №{numberPage} не удалось извлечь");
									}
								}
								else
								{
									bondsLogger.Error("Количество столбцов на сайте изменилось. Данные не удается получить.");
								}
							}
							catch (Exception ex)
							{
								bondsLogger.Error($"Ошибка: {ex}");
							}
						}
					}
				}
				else
				{
					bondsLogger.Error($"Подключиться не удалось. {_httpResponseMessage.StatusCode}");
				}
				numberPage++;
			}
			while (numberPage <= 442);
			try
			{
				bondsLogger.Info($"Идет запись в файл по пути: {CSVFilePath}");
				_csvWriter.Write(CSVFilePath, bonds);
				bondsLogger.Info($"Данные записаны в файл. Количество {bonds.Count} из {bonds.Count}");
				//отправка на сервер
				_fileSender.Send(CSVFilePath, _webServiceUrl, _type);
			}
			catch (Exception ex)
			{
				bondsLogger.Error($"Ошибка: {ex}");
			}
			return null;
		}
	}
}
