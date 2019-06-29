using System;
using System.IO;
using McMaster.Extensions.CommandLineUtils;

namespace global.project.structure
{
    class Program
    {
        [Option(CommandOptionType.NoValue)]
        public bool precheck { get; }
        [Option(CommandOptionType.NoValue)]
        public bool defaultpromptoyes { get; }
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
                bool createLicense = false;
                
                if ( defaultpromptoyes )
                {
                    createLicense = true;
                }
                else
                {
                   createLicense = = Prompt.GetYesNo("Would you like to create a license file holder?",true,ConsoleColor.DarkYellow);
                }
                 
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
                bool createEditor = false;
                
                if ( defaultpromptoyes )
                {

                }
                else
                {
                   var createEditor = Prompt.GetYesNo("Would you like to create a contributing markdown file.",true,ConsoleColor.DarkYellow);
                }
                
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
                srcFolderExists = true;
            }
            //checking for the readme markdown file.
            if ( File.Exists("README.MD") )
            {
                readmeExists = true;
            }

            //checking for the editor.config file.
            if ( File.Exists(".editorconfig") )
            {
                editorConfigExists = true;
            }

            //checking for the license.txt file.
            if ( File.Exists("license.txt") )
            {
                licenseExists = true;
            }
            //checking for the license.txt file.
            if ( File.Exists("CONTRIBUTING.MD") )
            {
                contributingFileExists = true;
            }

            if ( File.Exists(".gitignore") )
            {
                gitignoreExists = true;
            }

            Console.WriteLine("\nInformation based on the precheck scan\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            if ( srcFolderExists )
            {
                Console.WriteLine("(Directory exists) ==========> Directory \"src\"");
            }

            if ( readmeExists )
            {
                Console.WriteLine("(File exists) ===============> README.md");
            }
            if ( editorConfigExists )
            {
                Console.WriteLine("(File exists) ===============> editor.config");
            }
            if ( licenseExists )
            {
               Console.WriteLine("(File exists) ===============> license.txt"); 
            }
            if ( contributingFileExists )
            {
                Console.WriteLine("(File exists) ===============> CONTRIBUTING.MD");
            }
            if ( gitignoreExists )
            {
               Console.WriteLine("(File exists) ===============> .gitignore"); 
            }
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.ForegroundColor = ConsoleColor.DarkRed;
            if ( !srcFolderExists )
            {
                Console.WriteLine("(Would be created) ==========> Directory \"src\"");
            }

            if ( !readmeExists )
            {
                Console.WriteLine("(Would be created) ==========> README.md");
            }
            if ( !editorConfigExists )
            {
                Console.WriteLine("(Would be created) ==========> editor.config");
            }
            if ( !licenseExists )
            {
               Console.WriteLine("(Would be created) ==========> license.txt"); 
            }
            if ( !contributingFileExists )
            {
                Console.WriteLine("(Would be created) ==========> CONTRIBUTING.MD");
            }
            if ( !gitignoreExists )
            {
                Console.WriteLine("(Would be created) ==========> .gitignore");
            }
            Console.ForegroundColor = ConsoleColor.Gray;

        }
    }
}
