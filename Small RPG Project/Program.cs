using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace Small_RPG_Project
{
     class Program
     {
          public static System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);        
          
          static void Main(string[] args)
          {
               
               int HasMatchStarted = 0;
               int Enemyhealth = 0;
               int health = 0;
               Console.Title = "Small RPG Project By: Grazty SB";
               int DamageMax = Convert.ToInt16(config.AppSettings.Settings["Level"].Value) * 50;
               void MainFunction()
               {
                    int TotalXP = Convert.ToInt16(config.AppSettings.Settings["Level"].Value) * 1000;
                    config.AppSettings.Settings["NeedExp"].Value = TotalXP.ToString();
                    config.Save(ConfigurationSaveMode.Modified, true);
                    if (config.AppSettings.Settings["Name"].Value == "")
                    {
                         Console.WriteAscii("Graztys RPG", Color.Cyan);
                         Console.ForegroundColor = Color.Orange;
                         Console.Write("Welcome To My Small Project Please Enter a Username!: ");
                         string optoionChoose = Console.ReadLine();
                         string Choose = optoionChoose.Replace("Welcome To My Small Project Please Enter a Username!: ", "");
                         config.AppSettings.Settings["Name"].Value = Choose;
                         config.Save(ConfigurationSaveMode.Modified, true);
                         MainFunction();
                    }
                    else
                    {
                         Console.Clear();
                         Console.WriteAscii("Graztys RPG", Color.Cyan);
                         Console.ForegroundColor = Color.Orange;
                         Console.WriteLine("Welcome " + config.AppSettings.Settings["Name"].Value + " To My Small Project Please Only Enter Numbers When Asked. Enjoy!");
                         Console.ForegroundColor = Color.White;
                         Console.WriteLine("----------------------");
                         Console.WriteLine("[1]: Fight");
                         Console.WriteLine("[2]: Level");
                         Console.WriteLine("[3]: Contact Me");
                         Console.Write("Pick A Number 1-3: ");
                         string optoionChoose = Console.ReadLine();
                         string Choose = optoionChoose.Replace("Pick A Option 1-3: ", "");
                         if (Choose == "1")
                         {
                              Fight();
                         }
                         else if (Choose == "2")
                         {
                              Console.Write("Current EXP is: ");
                              Console.ForegroundColor = Color.MediumPurple;
                              Console.WriteLine(config.AppSettings.Settings["CurrentExp"].Value + "/" + config.AppSettings.Settings["NeedExp"].Value+"!");
                              Console.ForegroundColor = Color.White;
                              Console.Write("Current Level is: ");
                              Console.ForegroundColor = Color.LightPink;
                              Console.WriteLine(config.AppSettings.Settings["Level"].Value +"!");
                              Console.ForegroundColor = Color.White;
                              System.Threading.Thread.Sleep(2000);
                              MainFunction();
                         }
                         else if (Choose == "3")
                         {
                              Console.WriteLine("You Picked to View Level!");
                              Console.ReadLine();
                         }
                         else
                         {
                              Console.WriteLine("Please only a # 1-3");
                              Console.WriteLine("---------------------------------");
                              MainFunction();
                         }
                    }
               }
               int Roll(int min, int max)
               {
                    Random random = new Random();
                    return random.Next(min, max);
               }
              
              void SetHP()
               {
                    int healthII = Convert.ToInt16(config.AppSettings.Settings["Level"].Value);
                    int HealthIII = healthII * 500;
                    health = HealthIII;
               }
               void SetMonsterHP()
               {
                    Random random = new Random();
                    int healthMaxStarter = Convert.ToInt16(config.AppSettings.Settings["Level"].Value);
                    int HealthMax = healthMaxStarter * 400;
                    int HealthMin = healthMaxStarter * 300;
                    Enemyhealth = random.Next(HealthMin, HealthMax);
               }
               void Fight()
               {                                                    
                    if(HasMatchStarted == 0)
                    {
                         HasMatchStarted = 1;
                         SetHP();
                         SetMonsterHP();
                         Console.Clear();
                         Console.ForegroundColor = Color.Red;
                         Console.WriteLine("Welcome To the Fight Arena " + config.AppSettings.Settings["Name"].Value + "!");
                         Console.ForegroundColor = Color.White;
                         Console.WriteLine("Your Current Opponent is a Skeleton!");
                         Console.Write("Current Opponents HP is: ");
                         Console.ForegroundColor = Color.Green;
                         Console.WriteLine(Enemyhealth);
                         Console.ForegroundColor = Color.White;
                         Console.Write(config.AppSettings.Settings["Name"].Value + " HP is: ");
                         Console.ForegroundColor = Color.Green;
                         Console.WriteLine(health);
                         Console.ForegroundColor = Color.White;
                         Console.WriteLine("[1]: Attack");
                         Console.WriteLine("[2]: Block");
                         Console.WriteLine("[3]: Flee");
                         Console.Write("Please Pick a Action to Do 1-3:");
                         string optoionChoose = Console.ReadLine();
                         string Choose = optoionChoose.Replace("Pick A Option 1-3: ", "");
                         if (Choose == "1")
                         {
                              Console.WriteLine("You Use SwordSlash To Hit the Enemy!");
                              System.Threading.Thread.Sleep(1000);
                              // do enemy attack here (Do a random on a min and max enemy damage by maxing being / the UsersTotalHp then min is one )
                              Random random = new Random();
                              int hit = random.Next(1, DamageMax);
                              int bet = hit;
                              Console.Write("Total Damage Done: ");
                              Console.ForegroundColor = Color.OrangeRed;
                              Console.WriteLine(bet);
                              Console.ForegroundColor = Color.White;
                              System.Threading.Thread.Sleep(1000);
                              Enemyhealth -= bet;
                              System.Threading.Thread.Sleep(1000);
                              if(Roll(1,10) < 5)
                              {
                                   Console.WriteLine("Now Its The Skeletons Turn!");
                                   System.Threading.Thread.Sleep(1000);
                                   // do enemy attack here (Do a random on a min and max enemy damage by maxing being / the UsersTotalHp then min is one )
                                   Random random1 = new Random();
                                   int hit1 = random1.Next(1, DamageMax);
                                   int bet1 = hit1;
                                   Console.Write("Skeleton Hit You With A Stab! Total Damage Done: ");
                                   Console.ForegroundColor = Color.OrangeRed;
                                   Console.WriteLine(bet1);
                                   Console.ForegroundColor = Color.White;
                                   System.Threading.Thread.Sleep(1000);
                                   health -= bet1;
                                   Fight();
                              }
                              else if(Roll(1,10)>=5)
                              {
                                   Console.ForegroundColor = Color.LightGreen;
                                   Console.WriteLine("You've Dodge The Skeltons Stab!");
                                   Console.ForegroundColor = Color.White;
                                   System.Threading.Thread.Sleep(1000);

                                   //does nothing goes back to main chooses
                                   Fight();
                              }
                         }
                         else if (Choose == "2")
                         {
                              if (Roll(1, 10) < 5)
                              {
                                   Console.WriteLine("You've Succefully Blocked Your opents Attack");
                                   System.Threading.Thread.Sleep(1000);

                                   //does nothing goes back to main chooses
                                   Fight();
                              }
                              else if (Roll(1, 10) >= 5)
                              {
                                  
                                   Console.WriteLine("You've Failed To Block Get Ready for A Nasty Hit!");
                                   System.Threading.Thread.Sleep(1000);
                                   // do enemy attack here (Do a random on a min and max enemy damage by maxing being / the UsersTotalHp then min is one )
                                   Random random = new Random();
                                   int hit = random.Next(1, DamageMax);
                                   int bet = hit;
                                   Console.Write("Goblin Hit You With A Stab! Total Damage Done: ");
                                   Console.ForegroundColor = Color.OrangeRed;
                                   Console.WriteLine(bet);
                                   Console.ForegroundColor = Color.White;
                                   System.Threading.Thread.Sleep(1000);
                                   health -= bet;
                                   Fight();
                              }
                         }
                         else if (Choose == "3")
                         {
                              HasMatchStarted = 0;
                              MainFunction();
                         }
                         else
                         {
                              Console.WriteLine("Please Select a Number 1-3 Then Press Enter");
                              System.Threading.Thread.Sleep(1000);
                              Fight();
                         }
                    }
                    else if (HasMatchStarted == 1)
                    {
                         if(health <= 0)
                         {
                              Console.Clear();
                              Console.ForegroundColor = Color.Red;
                              Console.WriteLine("Youve Died Better Luck Next Time");
                              System.Threading.Thread.Sleep(1000);
                              Console.ForegroundColor = Color.White;
                              MainFunction();
                              HasMatchStarted = 0;
                         }
                         else
                         {
                              Console.WriteLine("-----------------------------------------------");
                              Console.Write("Current Opponents HP is: ");
                              Console.ForegroundColor = Color.Green;
                              Console.WriteLine(Enemyhealth);
                              Console.ForegroundColor = Color.White;
                              Console.Write(config.AppSettings.Settings["Name"].Value + " HP is: ");
                              Console.ForegroundColor = Color.Green;
                              Console.WriteLine(health);
                              Console.ForegroundColor = Color.White;
                              Console.WriteLine("[1]: Attack");
                              Console.WriteLine("[2]: Block");
                              Console.WriteLine("[3]: Flee");
                              Console.Write("Please Pick a Action to Do 1-3:");
                              string optoionChoose = Console.ReadLine();
                              string Choose = optoionChoose.Replace("Pick A Option 1-3: ", "");
                              if (Choose == "1")
                              {
                                   Console.WriteLine("You Use SwordSlash To Hit the Enemy!");
                                   System.Threading.Thread.Sleep(1000);
                                   // do enemy attack here (Do a random on a min and max enemy damage by maxing being / the UsersTotalHp then min is one )
                                   Random random = new Random();
                                   int hit = random.Next(1, DamageMax);
                                   int bet = hit;
                                   Console.Write("Total Damage Done: ");
                                   Console.ForegroundColor = Color.OrangeRed;
                                   Console.WriteLine(bet);
                                   Console.ForegroundColor = Color.White;
                                   System.Threading.Thread.Sleep(1000);
                                   Enemyhealth -= bet;
                                   if (Enemyhealth <= 0)
                                   {
                                        SetMonsterHP();
                                        int currentexp = Convert.ToInt16(config.AppSettings.Settings["CurrentExp"].Value);
                                        int totalExp = Convert.ToInt16(config.AppSettings.Settings["NeedExp"].Value);
                                        Console.WriteLine("You've Defeted the Enemy Congrats!");
                                        Console.Write("You've Been Rewared: ");
                                        Console.ForegroundColor = Color.SeaGreen;
                                        Console.WriteLine(Enemyhealth + " Exp");
                                        currentexp += Enemyhealth;
                                        config.AppSettings.Settings["CurrentExp"].Value = currentexp.ToString();
                                        System.Threading.Thread.Sleep(2000);

                                        if(currentexp >=totalExp )
                                        {
                                             int level = Convert.ToInt32(config.AppSettings.Settings["Level"].Value);
                                             Console.WriteLine("You've Succesfully Leveled UP");
                                             int hey = Convert.ToInt32(config.AppSettings.Settings["CurrentExp"].Value);
                                             hey -= Convert.ToInt32(config.AppSettings.Settings["NeedExp"].Value);
                                             config.AppSettings.Settings["CurrentExp"].Value = hey.ToString();
                                             level += 1;
                                             config.AppSettings.Settings["Level"].Value = level.ToString();
                                             System.Threading.Thread.Sleep(2000);
                                             HasMatchStarted = 0;
                                             config.Save(ConfigurationSaveMode.Modified, true);
                                             MainFunction();
                                        }
                                        else
                                        {
                                             HasMatchStarted = 0;
                                             MainFunction();
                                        }
                                        
                                   }
                                   else
                                   {
                                        System.Threading.Thread.Sleep(1000);
                                        if (Roll(1, 10) < 5)
                                        {
                                             Console.WriteLine("Now Its The Skeletons Turn!");
                                             System.Threading.Thread.Sleep(1000);
                                             // do enemy attack here (Do a random on a min and max enemy damage by maxing being / the UsersTotalHp then min is one )
                                             Random random1 = new Random();
                                             int hit1 = random1.Next(1, DamageMax);
                                             int bet1 = hit1;
                                             Console.Write("Skeleton Hit You With A Stab! Total Damage Done: ");
                                             Console.ForegroundColor = Color.OrangeRed;
                                             Console.WriteLine(bet1);
                                             Console.ForegroundColor = Color.White;
                                             System.Threading.Thread.Sleep(1000);
                                             health -= bet1;
                                             Fight();
                                        }
                                        else if (Roll(1, 10) >= 5)
                                        {
                                             Console.ForegroundColor = Color.LightGreen;
                                             Console.WriteLine("You've Dodge The Skeltons Stab!");
                                             Console.ForegroundColor = Color.White;
                                             System.Threading.Thread.Sleep(1000);

                                             //does nothing goes back to main chooses
                                             Fight();
                                        }
                                   }
                              }
                              else if (Choose == "2")
                              {
                                   if (Roll(1, 10) < 5)
                                   {

                                        Console.WriteLine("You've Succefully Blocked Your opents Attack");
                                        System.Threading.Thread.Sleep(3000);
                                        //does nothing goes back to main chooses
                                        Fight();
                                   }
                                   else if (Roll(1, 10) >= 5)
                                   {
                                        Console.WriteLine("You've Failed To Block Get Ready for A Nasty Hit!");
                                        System.Threading.Thread.Sleep(1000);
                                        // do enemy attack here
                                        Random random = new Random();
                                        int hit = random.Next(1, 50);
                                        int bet = hit;
                                        Console.Write("Goblin Hit You With A Stab! Total Damage Done: ");
                                        Console.ForegroundColor = Color.OrangeRed;
                                        Console.WriteLine(bet);
                                        Console.ForegroundColor = Color.White;
                                        System.Threading.Thread.Sleep(1000);
                                        health -= bet;
                                        Fight();



                                   }
                              }
                              else if (Choose == "3")
                              {
                                   HasMatchStarted = 0;
                                   MainFunction();

                              }
                              else
                              {
                                   Console.WriteLine("Please Select a Number 1-3 Then Press Enter");
                                   System.Threading.Thread.Sleep(1000);
                                   Fight();
                              }
                         }
                    }
                         
                                       
               }               
               MainFunction();

          }
     }
}
