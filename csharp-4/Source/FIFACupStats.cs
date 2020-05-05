using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Challenge
{
    public class FIFACupStats
    {       
        public string CSVFilePath { get; set; } = "data.csv";

        public Encoding CSVEncoding { get; set; } = Encoding.UTF8;

        public int NationalityDistinctCount()
        {
            throw new NotImplementedException();
        }

        public int ClubDistinctCount()
        {
            throw new NotImplementedException();
        }

        public List<string> First20Players()
        {
            throw new NotImplementedException();
        }

        public List<string> Top10PlayersByReleaseClause()
        {            
            throw new NotImplementedException();        
        }
        
        public List<string> Top10PlayersByAge()
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, int> AgeCountMap()
        {
            throw new NotImplementedException();
        }
    }
}
