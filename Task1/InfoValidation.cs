using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task1
{
	public class InfoValidation
	{
		public string FirstName;
		public string LastName;
		public string PhoneNumber;

		public InfoValidation(string first_name, string last_name, string phone_number)
		{
			string phoneNum;
			if (isValidPhone(phone_number, out phoneNum))
			{
				FirstName = nameFormatting(first_name);
				LastName = nameFormatting(last_name);
				PhoneNumber = phoneFormatting(phoneNum);
				Console.WriteLine($"{FirstName} {LastName} {PhoneNumber}");
			}
			else
			{
				Console.WriteLine($"Неверный формат: {phoneNum}");
			}
		}

		public string nameFormatting(string name)
		{
			string temp = name.Replace(" ", "");
			string new_name = temp.Substring(0, 1).ToUpper() + temp.Substring(1);
			Console.WriteLine($"{new_name}"); //убрать потом
			return new_name;
		}

		public string phoneFormatting(string phone)
		{
			string temp = String.Concat("+", phone);
			string new_phoneNum = $"{temp.Substring(0, 2)}({temp.Substring(2, 3)})" +
				$"{temp.Substring(5, 3)}-{temp.Substring(8, 2)}-{temp.Substring(10)}";
			Console.WriteLine($"{new_phoneNum}");
			return new_phoneNum;
			//+X(XXX) XXX - XX - XX.
		}

		public bool isValidPhone(string phone, out string phoneNum)
		{
			Regex regex = new Regex(@"\D");
			string formattedPhone = regex.Replace(phone, "");
			phoneNum = formattedPhone;
			Console.WriteLine($"{formattedPhone}"); //убрать потом
			if (formattedPhone.Length == 11) return true;
			return false;
		}
	}
}
//Валидация и Форматирование Номера Телефона
//Требования:
//1.Входные поля: Имя(FirstName), Фамилия(LastName), Телефон(PhoneNumber).
//2.Форматирование Имени / Фамилии: Удалить пробелы и применить стандартный регистр.
//3. Валидация и Форматирование Телефона:
//    ◦ Из строки телефона удалить все нецифровые символы (скобки, пробелы, дефисы).
//    ◦ Проверить, что итоговая строка содержит ровно 11 цифр (например, с кодом страны).
//    ◦ Если валидация успешна, отформатировать телефон в международном формате: +X(XXX) XXX - XX - XX.
//    ◦ Если валидация неуспешна, вернуть телефон как "Неверный формат".
//4. Вывод: Полное отформатированное имя и результат обработки телефона.
