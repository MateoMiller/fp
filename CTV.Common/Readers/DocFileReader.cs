﻿using System.IO;
using System.Text;
using Spire.Doc;
using Spire.Doc.Documents;

namespace CTV.Common.Readers
{
    public class DocFileReader: IFileReader
    {
        public string ReadToEnd(Stream inputSteam)
        {
            var sb = new StringBuilder();
            var doc = new Document(inputSteam);
            foreach (Section section in doc.Sections)
            {
                foreach (Paragraph paragraph in section.Paragraphs)
                {
                    sb.AppendLine(paragraph.Text);
                }
            }

            return sb.ToString();
        }
    }
}