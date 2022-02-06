//
// Домашнее задание к занятию 16. Работа с JSON.
//
// Задача 1. Необходимо разработать программу для записи информации о товаре в текстовый файл в формате json.
//
// Разработать класс для моделирования объекта «Товар». Предусмотреть члены класса «Код товара» (целое число), «Название товара» (строка), «Цена товара» (вещественное число).
// Создать массив из 5-ти товаров, значения должны вводиться пользователем с клавиатуры.
// Сериализовать массив в json-строку, сохранить ее программно в файл «Products.json»
//
// Задача 2. Необходимо разработать программу для получения информации о товаре из json-файла.
// Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.
// 

using DZ16;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

 
// Определяем количество позиций товара
int n=5;
// Создаем массив products из n товаров
Products[] products = new Products[n];
// Вводим информацию о товаре
for (int i = 0; i < n; i++)
{
    Console.WriteLine("Введите код товара");
    int code;
    while (!int.TryParse(Console.ReadLine(), out code))
    {
        Console.WriteLine("Ошибка ввода! Введите целое число");
    }
    Console.WriteLine("Введите название товара");
    string name = Console.ReadLine();
    Console.WriteLine("Введите цену товара");
    double price;
    while (!double.TryParse(Console.ReadLine(), out price))
    {
        Console.WriteLine("Ошибка ввода! Введите целое число");
    }
    products[i]= new Products() { Code = code, Name = name, Price = price };
    Console.WriteLine();
}
// Задаем опции options для обработки кириллицы
JsonSerializerOptions options = new JsonSerializerOptions()
{
    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
    WriteIndented = true
};
// Получаем строку jsonString из массива products с учетом кириллицы (options)
string jsonString = JsonSerializer.Serialize(products, options);
// Записываем строку jsonString в фай лProducts.json
using (StreamWriter sw = new StreamWriter("../../../../Products.json"))
{
    sw.WriteLine(jsonString);
}
 