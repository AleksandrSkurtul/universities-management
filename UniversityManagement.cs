using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Universities
{
	internal class UniversityManagement
	{
		string pathforuniversity = @"universities.txt";
		string pathforstudent = @"students.txt";
		string action;
		bool exit = false;
		List<University> universities = new List<University>();

		public void Display() // show university and their students
		{
			foreach (University univer in universities)
			{
				Console.WriteLine(univer.name + "\nStudents: ");
				foreach (var stud in univer.student)
				{
					Console.WriteLine("{0} {1}", stud.firstname, stud.lastname);
				}
				Console.WriteLine("--------------");
			}
		}

		public void DisplayUniversityInfo()
		{
			
			foreach (var univer in universities)
			{
				double newuniversitybudget = 0;
				foreach (var student in univer.student)
				{
					if (student.graduating > DateTime.Now)
					{ newuniversitybudget += student.contract; }
				}
				univer.budget = newuniversitybudget;
				Console.WriteLine($"University: {univer.name}\nAddress: {univer.address}\nPhone: {univer.phone}\nBudget: {univer.budget}$");
				Console.WriteLine("--------------");
			}
		}

		public void WriteToFile()
		{
			File.Delete(pathforuniversity);
			File.Delete(pathforstudent);
			foreach (var univer in universities)
			{
				string universitytext = $"{univer.id}@{univer.name}@{univer.address}@{univer.phone}@" + Environment.NewLine;
				File.AppendAllText(pathforuniversity, universitytext);
				foreach (var student in univer.student)
				{
					string studenttext = $"{student.id}@{student.firstname}@{student.lastname}@{student.contract}@{student.entrance}@{student.graduating}@" + Environment.NewLine;
					File.AppendAllText(pathforstudent, studenttext);
				}
			}
		}

		public void StartProgram()
		{
			if (!File.Exists(pathforuniversity))
			{
				universities.Add(
				new University(0, "PGUPS", "190031 Saint Petersburg, 9 Moskovsky pr.", "+7 (812) 457-82-42", new List<Student>()
				{ new Student {id=0, firstname="Aleksandr", lastname = "Skurtul", contract = 60000, entrance = new DateTime(2014, 9, 1), graduating = new DateTime(2020, 7, 1)},
				new Student {id=0, firstname="Alexey", lastname = "Petrenko", contract = 48000, entrance = new DateTime(2014, 9, 1), graduating = new DateTime(2020, 7, 1)} }));

				universities.Add(
				new University(1, "ITMO", "49 Kronverksky Pr.St. Petersburg, 197101 Russia", "+7 (812) 232-97-04", new List<Student>()
				{ new Student {id=1, firstname="Vlad", lastname = "Gulyaev", contract = 25000, entrance = new DateTime(2012, 9, 1), graduating = new DateTime(2016, 7, 1)},
				new Student {id=1, firstname="Pavel", lastname = "Denisevich", contract = 30000, entrance = new DateTime(2012, 9, 1), graduating = new DateTime(2017, 7, 1)},
				new Student {id=1, firstname="Peonid", lastname = "Lotorak", contract = 10000, entrance = new DateTime(2015, 9, 1), graduating = new DateTime(2020, 7, 1)} })
				);
				WriteToFile();
			}

			else if (File.Exists(pathforuniversity))
			{

				string[] universitytext = File.ReadAllLines(pathforuniversity);
				string[] studenttext = File.ReadAllLines(pathforstudent);

				for (int i = 0; i < universitytext.Count(); i++)
				{
					string[] saveduniversityinfo = universitytext[i].Split('@');
					string id = saveduniversityinfo[0];
					string name = saveduniversityinfo[1];
					string address = saveduniversityinfo[2];
					string phone = saveduniversityinfo[3];
					universities.Add(new University(Int32.Parse(id), name, address, phone, new List<Student>()));
				}
				for (int j = 0; j < studenttext.Count(); j++)
				{
					string[] savedstudentinfo = studenttext[j].Split('@');
					foreach (var u in universities)
					{
						if (Int32.Parse(savedstudentinfo[0]) == u.id)
						{
							u.student.Add(new Student(Int32.Parse(savedstudentinfo[0]), savedstudentinfo[1], savedstudentinfo[2], Double.Parse(savedstudentinfo[3]), DateTime.Parse(savedstudentinfo[4]), DateTime.Parse(savedstudentinfo[5])));
						}
					}
				}
			}

			while (!exit)
			{
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("1 to add new university\n2 to add new student\n3 to display universities and their students\n4 to display full info about universities\n5 to delete data\n6 to save-exit");
				Console.ResetColor();
				Console.WriteLine("--------------");
				action = Console.ReadLine();

				switch (action)
				{
					case "1": //add new university
						var maxid = universities.Max(x => x.id);
						int newid = ++maxid;
						Console.WriteLine("Enter name: ");
						string newname = Console.ReadLine();
						Console.WriteLine("Enter address: ");
						string newaddress = Console.ReadLine();
						Console.WriteLine("Enter phone: ");
						string newphone = Console.ReadLine();
						universities.Add(new University(newid, newname, newaddress, newphone, new List<Student>()));
					//	string universitytext = $"{newid}@{newname}@{newaddress}@{newphone}@" + Environment.NewLine;
					//	File.AppendAllText(pathforuniversity, universitytext);
						break;

					case "2": //add new student
						Console.WriteLine("Choose university's ID: ");
						foreach (var university in universities)
						{
							Console.WriteLine(university.id + " " + university.name);
						}
						string n = Console.ReadLine();
						var addstudent = universities.FirstOrDefault(j => j.id == Int32.Parse(n));
						Console.WriteLine("Enter firstname: ");
						string newfirstname = Console.ReadLine();
						Console.WriteLine("Enter lastname: ");
						string newlastname = Console.ReadLine();
						Console.WriteLine("Enter contract: ");
						double newcontract = Convert.ToDouble(Console.ReadLine());
						Console.WriteLine("Enter the date of entrance: ");
						DateTime newentrance = Convert.ToDateTime(Console.ReadLine());
						Console.WriteLine("Enter the date of graduating: ");
						DateTime newgraduating = Convert.ToDateTime(Console.ReadLine());
						addstudent.student.Add(new Student(Int32.Parse(n), newfirstname, newlastname, newcontract, newentrance, newgraduating));
					//	string studenttext = $"{n}@{newfirstname}@{newlastname}@{newcontract}@{newentrance}@{newgraduating}@" + Environment.NewLine;
					//	File.AppendAllText(pathforstudent, studenttext);
						break;

					case "3": //universities and their students
						Display();
						break;

					case "4": //university info
						DisplayUniversityInfo();
						break;

					case "5": //delete
						Console.WriteLine("What do you want to delete?\n1 to University\n2 to Student");
						char choice = Convert.ToChar(Console.ReadLine());

						switch (choice)
						{
							case '1': //university
								Console.WriteLine("Choose university's ID: ");
								foreach (var university in universities)
								{
									Console.WriteLine(university.id + " " + university.name);
								}
								string choiceuniversity = Console.ReadLine();
								var removeuniversity = universities.FirstOrDefault(j => j.id == Int32.Parse(choiceuniversity));
								universities.Remove(removeuniversity);

								break;

							case '2':
								Console.WriteLine("Choose \"university's id\"");
								foreach (var university in universities)
								{
									Console.WriteLine(university.id + " " + university.name);
								}
								string removestudent = Console.ReadLine();
								var remove = universities.FirstOrDefault(j => j.id == Int32.Parse(removestudent));
								Console.WriteLine("Choose \"laststname\" of student you want to KICK!!!");
								foreach (var stude in remove.student)
								{
									Console.WriteLine("{0} {1}", stude.lastname, stude.firstname);
								}
								Console.WriteLine("--------------");

								string student = Console.ReadLine();
								var stud = remove.student.FirstOrDefault(x => x.lastname == student);
								remove.student.Remove(stud);

								break;

							default:
								break;
						}
						//File.Delete(pathforuniversity);
						//File.Delete(pathforstudent);
						//WriteToFile();
						break;

					case "6":
						exit = true;
						break;

					default:
						Console.Clear();
						Console.WriteLine("You selected wrong command!");
						System.Threading.Thread.Sleep(1000);
						break;
				}
				
				Console.WriteLine("Press any key");
				Console.ReadKey();
				Console.Clear();
			}
			//File.Delete(pathforuniversity);
			//File.Delete(pathforstudent);
			//string[] universitytext = File.ReadAllLines(pathforuniversity);
			//string[] studenttext = File.ReadAllLines(pathforstudent);
			WriteToFile();
		}
	}
}
