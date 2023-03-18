using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace _04_02_UsingINotifyPropertyChanged
{
  public class SampleData : INotifyPropertyChanged
  {
    private static Random rgen;

    private int _count;
    private List<string> _nameList;
    private List<string> _reserveList;

    public int Count
    {
      get { return _count; }
      set
      {
        _count = value;
        OnPropertyChanged();
      }
    }

    public List<string> NameList
    {
      get { return _nameList; }
      set
      {
        _nameList = value;
        OnPropertyChanged();
      }
    }

    public List<string> ReserveList
    {
      get { return _reserveList; }
      set
      {
        _reserveList = value;
        OnPropertyChanged();
      }
    }

    public SampleData()
    {
      rgen = new Random();
      _count = 0;
      _nameList = new List<string> { "Alice", "Bob", "Charlie", "David", "Eamon" };
      _reserveList = new List<string> { "Fred", "George", "Helen", "Ian", "Jeremy", "Kate", "Leonard", "Mary" };
    }

    public void Substitute()
    {
      var i = rgen.Next(_nameList.Count);
      var j = rgen.Next(_reserveList.Count);
      var temp = _nameList[i];
      _nameList[i] = _reserveList[j];
      _reserveList[j] = temp;

      NameList = new List<string>(_nameList);
      ReserveList = new List<string>(_reserveList);
      Count++;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

  }
}
