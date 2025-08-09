using System.ComponentModel.Design;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Threading.Tasks;

namespace To_Do_List___first_project_
{
    internal class Program
    {
        static void Main(string[] args)
        {
          Console.ForegroundColor = ConsoleColor.Magenta;
          Console.WriteLine("Welcome to Your To-Do List!");
          Console.ResetColor();

          List<Tasks> theList = new List<Tasks>(); // Create a list to store the tasks


          while (true) // Infinite loop to keep showing the menu until the user exits
          {

            /* Show menu options to the user */
            Console.WriteLine("Menu :\n1)Add Task\n2)View Task\n3)Delete Task\n4)Modify Task\n5)Exit\nPlease Choose an option:");
            string desire = Console.ReadLine()!;

            if (desire == "1") // Option 1: Add a task
            {
                Tasks y = new Tasks();
                y.addingtask();
                y.addingduration();
                theList.Add(y);
                Console.WriteLine("Task added!");
            }
          
            else if (desire == "2") // option 2 : view all tasks
            {
              Console.WriteLine("your list");
              foreach (Tasks t in theList)
              {
                 t.display();
              }
            }

            else if (desire == "3") // option 3 : delete a task 
            {
               Tasks.delete(theList);
            }
            
            else if (desire == "4") // option 4 : modify a task
            {
              Console.WriteLine("Your current list:");
              foreach (Tasks t in theList)
              {                    
                 t.display();
              }
              
              string name;
              while (true)
              {
                  Console.WriteLine("Enter the task name you want to modify:");
                  name = Console.ReadLine()!;
                 
                  if (string.IsNullOrWhiteSpace(name))
                  {
                    Console.WriteLine("Invalid Input");
                  }
                  else if (name.Any(char.IsDigit))
                  {
                    Console.WriteLine("Invalid Input");
                  }
                  else
                  {
                     break; 
                  }
              }

              bool check = false;

              foreach (Tasks t in theList)
              {
                if (t.taskbody() == name)
                {
                     t.modify();
                     check = true;
                     break;
                }
              }

              if (!check)
              {           
                   Console.WriteLine("No task found with that name.");
              }
             
              else
              {
                Console.WriteLine("Your updated list:");
                foreach (Tasks k in theList)
                {
                  k.display();
                } 
              }
            }
           
            else if (desire == "5") // option5 : exit 
            {
              if(theList.Count != 0)
              {
                  Console.WriteLine("Final To-Do List:");
                  foreach (Tasks k in theList)
                  {
                     k.display();
                  }
                  Console.ForegroundColor = ConsoleColor.Magenta;
                  Console.WriteLine("Thank you for using the To-Do List App!");
                  Console.ResetColor();
              }
             
              else if (theList.Count== 0)
              {
                Console.WriteLine("Your list is empty");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Thank you for using the To-Do List App!");
                Console.ResetColor();
              }
                break;

            }
          }
        }
    }
   
    /* Class representing a task */
    class Tasks
    {
        string taskBody;
        uint duration;
        public void addingtask() // method to add the task
        {
            Console.WriteLine("Please enter the task:");
            while (true)
            {
                taskBody = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(taskBody))
                {
                    Console.WriteLine("Task cannot be empty. Please enter a valid task");
                    continue;
                }
                break;
            }
        }
        public void addingduration() // method to add duration ( in min )
        {
            Console.WriteLine("Please enter the duration (in minutes)");
            while (true)
            {
                try
                {
                    duration = uint.Parse(Console.ReadLine()!);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a positive number");
                }
            }
        }
        public void display() // method to display a task
        {
            Console.WriteLine($"{taskBody} ({duration} min)");
        }
        public void modify() // method to modify a task
        {
            Console.WriteLine("Enter the new task");
            while (true)
            {
                string newtask = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(newtask))
                {
                    Console.WriteLine("Task cannot be empty. Please enter a valid task:");
                }
                else if (newtask.Any(char.IsDigit))
                {
                    Console.WriteLine("Warning: Task cannot contain numbers!");
                }
                else
                {
                    taskBody = newtask;
                    break;
                }
            }
            Console.WriteLine("Enter the new duration (in minutes)");
            while (true)
            {
                if (uint.TryParse(Console.ReadLine(), out uint newduration))
                {
                    duration = newduration;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive number.");
                }
            }
        }
        public static void delete(List<Tasks> theList) // method to delete a task
        {
            
           Console.WriteLine("Your current list:");
           foreach (Tasks task in theList)
           {
              Console.WriteLine(task.taskbody());
           }
          
           Console.WriteLine("Enter the name of the task you want to delete");
          
           string remove = Console.ReadLine()!;
           
           bool check = false;
           for (int i = 0; i < theList.Count; i++)
           {
              if (remove == theList[i].taskbody())
              {
                  theList.RemoveAt(i);
                  check = true;
                  break;
              }
           }
           if (!check)
           {
              Console.WriteLine("Task not found");
           }
            Console.WriteLine();
            Console.WriteLine("Your updated list:");
            Console.WriteLine();
            foreach (Tasks t in theList)
            {
               t.display();
            }
        }
        public string taskbody() // Method to return the task
        {
            return taskBody; 
        }

    }  
}
        


    




