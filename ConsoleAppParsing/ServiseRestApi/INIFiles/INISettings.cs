using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ConsoleAppParsing.ServiseRestApi.INIFiles
{
    class INISettings
    {
        public INISettings(string iniFilePath)
        {
            _iniFilePath = iniFilePath;
        }
        //Импорт функции GetPrivateProfileString (для чтения значений) из библиотеки kernel32.dll
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
        private static extern int GetPrivateString(string _section, string _key, string _def, StringBuilder _buffer, int _size, string _iniFilePath);
        //Импорт функции WritePrivateProfileString (для записи значений) из библиотеки kernel32.dll
        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
        private static extern int WritePrivateString(string _section, string _key, string str, string _iniFilePath);
        public INISettings() : this("") { }
        //Возвращает значение из INI-файла (по указанным секции и ключу) 
        public string GetPrivateString(string _section, string _key)
        {
            //Для получения значения
            StringBuilder _buffer = new StringBuilder(SIZE);
            //Получить значение в buffer
            GetPrivateString(_section, _key, null, _buffer, SIZE, _iniFilePath);
            //Вернуть полученное значение
            return _buffer.ToString();
        }
        //Пишет значение в INI-файл (по указанным секции и ключу) 
        public void WritePrivateString(string _section, string _key, string _value)
        {
            //Записать значение в INI-файл
            WritePrivateString(_section, _key, _value, _iniFilePath);
        }
        //Возвращает или устанавливает путь к INI файлу
        public string Path { get { return _iniFilePath; } set { _iniFilePath = value; } }
        //Поля класса
        private const int SIZE = 1024; //Максимальный размер (для чтения значения из файла)
        private string _iniFilePath = null; //Для хранения пути к INI-файлу
    }
}
