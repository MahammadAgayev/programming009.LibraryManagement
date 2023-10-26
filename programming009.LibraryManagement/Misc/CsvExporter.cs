using programming009.LibraryManagement.Misc.Abstract;
using programming009.LibraryManagement.Models;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
//ctrl r + g

namespace programming009.LibraryManagement.Misc
{
    //csv ==> comma seperated values
    //Id,Name,Surname
    //1,Mahammad,Aghayev

    public class ColumnInfo
    {
        public ReportFieldAttribute ReportField { get; set; }
        public PropertyInfo Prop { get; set; }
    }

    public class CsvExporter<T> : IExporter<T>
    {
        public void Export(IEnumerable<T> objects)
        {
            if (objects.Count() == 0)
            {
                throw new InvalidOperationException("There's no data in report");
            }

            Type t = typeof(T);

            PropertyInfo[] properties = t.GetProperties();
            List<ColumnInfo> propertiesToShow = new List<ColumnInfo>(properties.Length);


            foreach (PropertyInfo prop in properties)
            {
                ReportFieldAttribute attribute = prop.GetCustomAttribute<ReportFieldAttribute>();

                if (attribute == null)
                {
                    continue;
                }

                propertiesToShow.Add(new ColumnInfo
                {
                    Prop = prop,
                    ReportField = attribute
                });
            }

            propertiesToShow = propertiesToShow.OrderBy(x => x.ReportField.Order).ToList();

            StringBuilder text = new StringBuilder();

            bool isFirst = true;
            foreach (ColumnInfo property in propertiesToShow)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    text.Append(",");
                }

                text.Append(property.ReportField.DisplayName);
            }

            text.AppendLine();

            foreach (T data in objects)
            {
                isFirst = true;
                foreach (ColumnInfo prop in propertiesToShow)
                {
                    if (isFirst)
                    {
                        isFirst = false;
                    }
                    else
                    {
                        text.Append(",");
                    }

                    text.Append($"\"{prop.Prop.GetValue(data)}\"");
                }

                text.AppendLine();
            }

            string path = GetDownloadsFolder();

            File.WriteAllText(path, text.ToString());
        }

        private string GetDownloadsFolder()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            return Path.Combine(folder, "LibraryManagement_Books.csv");
        }
    }
}
