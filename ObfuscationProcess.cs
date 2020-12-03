using System;
using System.IO;
using System.Text;
using Regalia;

namespace Regalia_Obfuscator
{
    public class ObfuscationProcess
    {
        public bool Obfuscate(string filepath, string savepath, int chartype, int length)
        {
            // Check if file is executable of type NET.
            if (!checkExecutable(filepath)) 
            {
                return false;
                throw new FileNotFoundException("Executable file is not of the type .NET");
            }

            RegaliaParameters parameters = new RegaliaParameters();
            parameters.Path = filepath;
            if (chartype.Equals(0))
            {
                parameters.CharacterType = RegaliaParameters.CharacterTypeSet.Arabic;
            }
            else if (chartype.Equals(1))
            {
                parameters.CharacterType = RegaliaParameters.CharacterTypeSet.Braille;
            }
            else
            {
                parameters.CharacterType = RegaliaParameters.CharacterTypeSet.Japanese;
            }
            parameters.StringLength = length;
            parameters.Generator = new Generator();

            Regalia.RegaliaInstance instance = new Regalia.RegaliaInstance(parameters);
            Console.WriteLine("Successfully loaded the assembly.");

            instance.Obfuscate();
            return instance.Save(savepath);
        }

        private bool checkExecutable(string filePath)
        {
            try
            {
                var bytes = new byte[2];
                using (var stream = File.Open(filePath, FileMode.Open))
                {
                    stream.Read(bytes, 0, 2); // Read the first 2 bytes of the EXE.
                }
                return Encoding.UTF8.GetString(bytes).Equals("MZ");

            } catch (FileNotFoundException fe) { Console.Write(fe.ToString()); return false; }
           
        }
    }
}
