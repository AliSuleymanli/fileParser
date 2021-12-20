using Parser.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Parser.Helper
{
    public class ParserClas : IParser
    {
        private const string SplitterLine = "----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";

        private List<MainChunk> FromTextToMainChunks(string text)
        {
            List<MainChunk> result = new List<MainChunk>();

            var splittedParts = text.Split(SplitterLine);

            foreach (var item in splittedParts)
            {
                result.Add(MainChunkTextToModel(item));
            }

            result.RemoveAt(result.Count - 1);

            return result;
        }

        private MainChunk MainChunkTextToModel(string text)
        {
            MainChunk result;
            List<MainChunkDetail> details = new List<MainChunkDetail>();

            string[] chunkBasicFieldValues = new string[5];
            int chunkBasicFieldValuesLength = chunkBasicFieldValues.Length;

            var chunkDetailFields = new string[11];
            int chunkDetailFieldsLength = chunkDetailFields.Length;

            using (StringReader reader = new StringReader(text))
            {
                string line = reader.ReadLine();
                reader.ReadLine();//line which is about total is read;
                int nonEmptyLineIndex = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    #region Preparation of Basic Chunk Fields

                    if (nonEmptyLineIndex < chunkBasicFieldValuesLength)
                    {
                        chunkBasicFieldValues[nonEmptyLineIndex] = line.Split(":")[1].Trim();

                        nonEmptyLineIndex++;

                        continue;
                    }

                    #endregion

                    #region Preparation of ChunkDetail Table Structure

                    if (nonEmptyLineIndex == chunkBasicFieldValuesLength)
                    {
                        chunkDetailFields = line.Split("+");

                        nonEmptyLineIndex++;
                        continue;
                    }

                    if (nonEmptyLineIndex <= chunkBasicFieldValuesLength + 3)
                    {
                        nonEmptyLineIndex++;
                        continue;
                    }

                    #endregion

                    #region Manipulation of ChunkDetail List

                    if (nonEmptyLineIndex > chunkBasicFieldValuesLength + 3)
                    {
                        int previousFieldLength = 0;
                        for (int i = 1; i < chunkDetailFieldsLength; i++)
                        {
                            chunkDetailFields[i] = line.Substring(chunkDetailFields[i - 1].Length + 1 + previousFieldLength, chunkDetailFields[i].Length);
                            previousFieldLength += chunkDetailFields[i - 1].Length + 1;
                        }

                        MainChunkDetail detail = new MainChunkDetail(chunkDetailFields);

                        details.Add(detail);

                        continue;
                    }

                    #endregion

                }
            }

            result = new MainChunk(chunkBasicFieldValues, details);

            return result;
        }

        private string readFromTextFile(string fileName)
        {
            string result;

            using (StreamReader sr = File.OpenText(fileName)) result = sr.ReadToEnd();

            return result;
        }

        public PageUploadTransaction readFromFileToList(string path)
        {
            string text = readFromTextFile(path);

            return new PageUploadTransaction
            {
                Id = 0,
                MainChunks = FromTextToMainChunks(text)
            };
        }
    }
}
