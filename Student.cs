using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universities
{
	public class Student
	{
		public int id;
		public string firstname;
		public string lastname;
		public double contract;
		public DateTime entrance;
		public DateTime graduating;

		public Student(int id, string firstname, string lastname, double contract, /*string university,*/ DateTime entrance, DateTime graduating)
		{
			this.id = id;
			this.firstname = firstname;
			this.lastname = lastname;
			this.contract = contract;
			this.entrance = entrance;
			this.graduating = graduating;
		}

		public Student()
		{
		}

		


	}

	

}
