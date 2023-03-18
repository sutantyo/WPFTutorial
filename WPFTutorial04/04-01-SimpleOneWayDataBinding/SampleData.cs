using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace _04_01_SimpleOneWayDataBinding
{
  public class SampleData 
  {
    private static Random rgen;

    public ObservableCollection<string> NameList { get; }
    public ObservableCollection<string> ReserveList { get; }

    public SampleData() 
    {
      rgen = new Random();
      NameList = new ObservableCollection<string> { "Alice", "Bob", "Charlie", "David", "Eamon" };
      ReserveList = new ObservableCollection<string> { "Fred", "George", "Helen", "Ian", "Jeremy", "Kate", "Leonard", "Mary" };
    }

    public void Substitute()
    {
      var i = rgen.Next(NameList.Count);
      var j = rgen.Next(ReserveList.Count);
      var temp = NameList[i];
      NameList[i] = ReserveList[j];
      ReserveList[j] = temp;
    }
  }
}
