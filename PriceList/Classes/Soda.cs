using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceList.Classes
{
    internal class Soda
    {
		private int _age;
		//Возраст
		public int Age
		{
			get { return _age; }
			set { _age = value; }
		}
		//Имя
		private string _name;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		//Фамилия
		private string _lastName;

		public string LastName
		{
			get { return _lastName; }
			set { _lastName = value; }
		}

		//Кол-во денег
		private int _money;

		public int MoneyCount
		{
			get { return _money; }
			set { _money = value; }
		}
		public Soda()
		{

		}

		public Soda(int age, string name, string lastName, int moneyCount)
		{
			Age = age;
			Name = name;
			LastName = lastName;
			MoneyCount = moneyCount;
		}
	}
}
