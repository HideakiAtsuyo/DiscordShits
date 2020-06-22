using System;
using System.Threading;
using Crayon;

namespace DiscordShitsHA
{
	class Program
	{
		public static void DisplayMenuOptions(string text, int time, string type)
		{
			if (type == "error")
			{
				Console.Write(Output.Red().Text(text + "\r\n"));
				Thread.Sleep(time);
			}
			else if (type == "info")
			{
				Console.Write(Output.Blue().Text(text + "\r\n"));
				Thread.Sleep(time);
			}
			else if (type == "category")
			{
				Console.Write(Output.White().Text(text + "\r\n"));
				Thread.Sleep(time);
			}
		}
		static void Main(string[] args)
		{
			Console.Title = "Discord Shits";
			for (; ; )
			{
				try
				{
					Console.Clear();
					DisplayMenuOptions("<= Tokens =>", 300, "category");
					DisplayMenuOptions("[1] - Token Ruiner", 200, "info");
					DisplayMenuOptions("[2] - Token Disabler", 200, "info");
					DisplayMenuOptions("<= Webhooks =>", 300, "category");
					DisplayMenuOptions("[3] - Webhooks Informations", 200, "info");
					DisplayMenuOptions("[4] - Webhooks Message", 200, "info");
					DisplayMenuOptions("[5] - Webhooks Disabler", 200, "info");
					DisplayMenuOptions("[6] - Webhooks Edit", 200, "info");

					Console.WriteLine();
					DisplayMenuOptions("Your chosen option is: ", 200, "category");//Oof
					int int_ = Convert.ToInt32(Console.ReadLine());
					switch (int_)
					{
						case 1:
							{

								DiscordClass.Ruiner();
								return;
							}
						case 2:
							{
								DiscordClass.Disabler();
								return;
							}
						case 3:
							{
								DiscordClass.infosWebhook();
								return;
							}
						case 4:
							{
								Program.DisplayMenuOptions("Put a webhook URL:", 200, "info");
								string URL = Console.ReadLine();
								Program.DisplayMenuOptions("Put a Username:", 200, "info");
								string Username = Console.ReadLine();
								Program.DisplayMenuOptions("Put an Avatar URL(png, jpg, etc...):", 200, "info");
								string AvatarURL = Console.ReadLine();
								Program.DisplayMenuOptions("Put a Message :", 200, "info");
								string Message = Console.ReadLine();

								DiscordClass.sendWebhook(URL, Username, AvatarURL, Message);
								return;
							}
						case 5:
							{
								Program.DisplayMenuOptions("Put a webhook URL:", 200, "info");
								string URL = Console.ReadLine();
								DiscordClass.removeWebhook(URL);
								return;
							}
						case 6:
							{
								Program.DisplayMenuOptions("Put a webhook URL:", 200, "info");
								string URL = Console.ReadLine();
								Program.DisplayMenuOptions("Put a Username:", 200, "info");
								string Username = Console.ReadLine();
								Program.DisplayMenuOptions("Put an Avatar URL(png, jpg, etc...):", 200, "info");
								string AvatarURL = Console.ReadLine();
					
								DiscordClass.editWebhook(URL, Username, AvatarURL);
								return;
							}

						default:
							DisplayMenuOptions("Please choose a valid option.", 200, "error");
							Console.ReadKey();
							Console.Clear();
							continue;
					}
					continue;
				}
				catch (Exception ex)
				{
					DisplayMenuOptions($"Please only use numbers to select an option.\n{ex}", 200, "error");
					Thread.Sleep(2000);
					Console.Clear();
					continue;
				}
			}
		}
	}
}
