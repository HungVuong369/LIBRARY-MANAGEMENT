using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class ReaderViewModel
    {
        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public ReaderRepository readerRepo { get; set; }

        public ReaderViewModel()
        {
            readerRepo = unitOfWork.Readers;
        }

        public bool isAdult(string idReader)
        {
            Reader reader = readerRepo.GetById(idReader);

            if (reader.ReaderType == true)
                return true;

            return false;
        }

        public bool isChild(string idReader)
        {
            Reader reader = readerRepo.GetById(idReader);

            if (reader.ReaderType == false)
                return true;

            return false;
        }
    }
}
