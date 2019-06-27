using System;
using System.IO;
using McMaster.Extensions.CommandLineUtils;

namespace global.project.structure
{
    class Program
    {
        [Option(CommandOptionType.NoValue)]
        public bool precheck { get; }  
        public string editorconfigtemplate { get ; }
        public string gitignoretemplate { get; }  
        static void Main(string[] args) => CommandLineApplication.Execute<Program>(args);

        private void OnExecute()
        {
            //  We should check the project directory for the following standard
            //  files
            //  "src"               A directory that is title src. This is where all
            //                      project source files reside.
            //  "README.MD"         A standard readme file for the project
            //  "license.txt"       If the project is open source, this should be the
            //                      standard open source license for the project
            //  ".editorconfig"     This file helps with providing coding stardards
            //  "CONTRIBUTING.MD"   For open source projects, this can be instructions
            //                      for contributing to the project.
            //  ".gitignore"        A standard file for ignoring .net based files fo
            //                      github

            if ( precheck )
            {
                preCheck();
                return;
            }

            //checking for src directory.
            if ( Directory.Exists("src") )
            {
                Console.WriteLine("src folder exists. Checking for other standard items in the project.");
            }
            else
            {
                //create the directory
                Directory.CreateDirectory("src");
            }
            //checking for the readme markdown file.
            if ( File.Exists("README.MD") )
            {
                //inform user that they already have a readme markdown file in the
                //project
                Console.WriteLine("ReadMe markdown file exists. Checking for other standard items in the project.");
            }
            else
            {
                //create the readme file and populating it with just a 
                //standard header
                File.WriteAllText("README.MD","# Please put your standard readme here");
            }

            //checking for the editor.config file.
            if ( File.Exists(".editorconfig") )
            {
                //inform user that they already have a editor.config in the
                //project
                Console.WriteLine("editor.config file exists. Checking for other standard items in the project.");
            }
            else
            {
                //create the editor.config file and populating it with just a 
                //blank json
                File.WriteAllText(".editorconfig","{}");
            }

            //checking for the license.txt file.
            if ( File.Exists("license.txt") )
            {
                //inform user that they already have a license.txt in the
                //project
                Console.WriteLine("license.txt file exists. Checking for other standard items in the project.");
            }
            else
            {
                bool createLicense = Prompt.GetYesNo("Would you like to create a license file holder?",true,ConsoleColor.DarkYellow);
                if ( createLicense )
                {
                    //create the license file and populating it with just a 
                    //blank json
                    File.WriteAllText("license.txt","");
                }
            }
            //checking for the license.txt file.
            if ( File.Exists("CONTRIBUTING.MD") )
            {
                //inform user that they already have a contributing markdown
                //file in the project
                Console.WriteLine("contributing markdown file exists. Checking for other standard items in the project.");
            }
            else
            {
                bool createEditor = Prompt.GetYesNo("Would you like to create a contributing markdown file.",true,ConsoleColor.DarkYellow);
                if ( createEditor)
                {
                    //create the editor.config file and populating it with just a 
                    //blank json
                    File.WriteAllText("CONTRIBUTING.MD","# CONTRIBUTING Guidelines");
                }
            }
            //checking for the .gitignore file.
            if ( File.Exists(".gitignore") )
            {
                //inform user that they already have a contributing markdown
                //file in the project
                Console.WriteLine(".gitignore file exists. Checking for other standard items in the project.");
            }
            else
            {
                //create the .gitignore file and populating it with just a 
                //blank json
                File.WriteAllText(".gitignore","bin\nobj\n");
            }
        }
        private void preCheck()
        {
            bool srcFolderExists = false;
            bool readmeExists = false;
            bool editorConfigExists = false;
            bool licenseExists = false;
            bool contributingFileExists = false;
            bool gitignoreExists = false;

            //only run the precheck and print out what files would be created/needed
            //in the project
            //checking for src directory.
            if ( Directory.Exists("src") )
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("src folder exists in project directory. Checking for other standard items in the project.");
                Console.ForegroundColor = ConsoleColor.Gray;
                srcFolderExists = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("src folder does not exist in project directory.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            //checking for the readme markdown file.
            if ( File.Exists("README.MD") )
            {
                //inform user that they already have a readme markdown file in the
                //project
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("ReadMe markdown file exists. Checking for other standard items in the project.");
                Console.ForegroundColor = ConsoleColor.Gray;
                readmeExists = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Project README does not exist in project directory.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            //checking for the editor.config file.
            if ( File.Exists("editor.config") )
            {
                //inform user that they already have a editor.config in the
                //project
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("editor.config file exists. Checking for other standard items in the project.");
                Console.ForegroundColor = ConsoleColor.Gray;
                editorConfigExists = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Project editor.config does not exist in project directory.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            //checking for the license.txt file.
            if ( File.Exists("license.txt") )
            {
                //inform user that they already have a license.txt in the
                //project
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("license.txt file exists. Checking for other standard items in the project.");
                Console.ForegroundColor = ConsoleColor.Gray;
                licenseExists = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("license.txt does not exist in project directory.");
                Console.ForegroundColor = ConsoleColor.Gray;           
            }
            //checking for the license.txt file.
            if ( File.Exists("CONTRIBUTING.MD") )
            {
                //inform user that they already have a contributing markdown
                //file in the project
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("contributing markdown file exists. Checking for other standard items in the project.");
                Console.ForegroundColor = ConsoleColor.Gray;
                contributingFileExists = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("contributing markdown file does not exist in project directory.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            if ( File.Exists(".gitignore") )
            {
                //inform user that they already have a contributing markdown
                //file in the project
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(".gitnore file exists. Checking for other standard items in the project.");
                Console.ForegroundColor = ConsoleColor.Gray;
                gitignoreExists = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(".gitignore file does not exist in project directory.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.WriteLine("Based on the precheck scan");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            if ( srcFolderExists )
            {
                Console.WriteLine("(Exists) \t\t folder \"src\"");
            }

            if ( readmeExists )
            {
                Console.WriteLine("(Exists) \t\t README.md");
            }
            if ( editorConfigExists )
            {
                Console.WriteLine("(Exists) \t\t editor.config");
            }
            if ( licenseExists )
            {
               Console.WriteLine("(Exists) \t\t license.txt"); 
            }
            if ( contributingFileExists )
            {
                Console.WriteLine("(Exists) \t\t CONTRIBUTING.MD");
            }
            if ( gitignoreExists )
            {
               Console.WriteLine("(Exists) \t\t .gitignore"); 
            }
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.ForegroundColor = ConsoleColor.DarkRed;
            if ( !srcFolderExists )
            {
                Console.WriteLine("(Would be created) \t\t folder \"src\"");
            }

            if ( !readmeExists )
            {
                Console.WriteLine("(Would be created) \t\t README.md");
            }
            if ( !editorConfigExists )
            {
                Console.WriteLine("(Would be created) \t\t editor.config");
            }
            if ( !licenseExists )
            {
               Console.WriteLine("(Would be created) \t\t license.txt"); 
            }
            if ( !contributingFileExists )
            {
                Console.WriteLine("(Would be created) \t\t CONTRIBUTING.MD");
            }
            if ( !gitignoreExists )
            {
                Console.WriteLine("(Would be created) \t\t .gitignore");
            }
            Console.ForegroundColor = ConsoleColor.Gray;

        }
    }
}
