using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universities
{
	public class University
	{
		public int id;
		public string name;
		public string address;
		public string phone;
		public List<Student> student;
		public double budget;

		public University() { }
		public University(int id, string name, string address, string phone, List<Student> student)
		{
			this.id = id;
			this.name = name;
			this.address = address;
			this.phone = phone;
			this.student = student;
			//budget =  ///need to put operation to sum budget using students
		}
		public University(string name, string address, string phone)
		{
			this.name = name;
			this.address = address;
			this.phone = phone;
			//this.student = student;
			//budget =  ///need to put operation to sum budget using students
		}


	}
}



