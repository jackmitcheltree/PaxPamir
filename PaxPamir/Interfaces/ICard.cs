using PaxPamir.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxPamir.Interfaces
{
    public interface ICard
    {
        public void Discard ();
        public void Purchase ();
        public CardType CardType { get; }
    }
}
