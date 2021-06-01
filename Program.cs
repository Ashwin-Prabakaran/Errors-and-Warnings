using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Program3
{
	class Program
	{
		static void Main(string[] args)
		{
			//Declaring list to store error and warning lines.
			List<string> errorLine = new List<string>();
			List<string> warningLine = new List<string>();

			//Getting input and output file paths from user.
			Console.WriteLine("Enter Log File Path");
			string logFilePath = Console.ReadLine();
			Console.WriteLine("Enter Parse Log File Path");
			string parseLogFilePath = Console.ReadLine();
			
			try
			{
				//Checking if input file exits.
				if (File.Exists(logFilePath))
				{
					//initializing stream reader to read the contents of the log file.
					using (StreamReader logFileReader = new StreamReader(logFilePath))
					{
						string line;//declaring to store line from reader.
						while ((line = logFileReader.ReadLine()) != null)
						{
							//Checking if line contains error or warning keywords. if yes append them to local list respectively.
							if (line.ToUpper().Contains("ERROR"))
							{
								errorLine.Add(line);
							}
							else if (line.ToUpper().Contains("WARNING"))
							{
								warningLine.Add(line);
							}
						}
						logFileReader.Close();
					}

					//Checking if parseLogFilepath exits if no creating a new log file in Log File directory path.
					if (!File.Exists(parseLogFilePath))
					{
						//Creating new file.
						Console.WriteLine("Creating Parse Log File");
						string directoryName = Path.GetDirectoryName(logFilePath);
						parseLogFilePath = directoryName + "\\\\" + "parseLogFile.txt";

					}

					//Writing error and warning logs into parselogfile.
					using (StreamWriter parseLogFileWriter = new StreamWriter(parseLogFilePath))
					{
						Console.WriteLine("Writing into Parse Log File");
						parseLogFileWriter.WriteLine("Error List:\n");
						foreach (string line in errorLine)
						{
							parseLogFileWriter.WriteLine("\t" + line);
						}

						parseLogFileWriter.WriteLine("Warning List:\n");
						foreach (string line in warningLine)
						{
							parseLogFileWriter.WriteLine("\t" + line);
						}
						Console.WriteLine("Parse Log File updated");
					}
				}
				else
				{
					//File does not exists.
					Console.WriteLine("Log File does not exist.");
				}
				Console.ReadLine();

			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Console.ReadLine();
			}

		}
	}
}
