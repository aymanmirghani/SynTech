using System;
using System.Collections.Generic;
using System.Text;

namespace MICS.BLL
{
    public class SimplePair
    {
        int _valueMember = 0;
        string _strValue = "";
        string _displayMember = String.Empty;
        public int ValueMember
        {
            get { return _valueMember; }
            set { _valueMember = value; }
        }
        public string StrValueMember
        {
            get { return _strValue; }
            set { _strValue = value; }
        }
        public string DisplayMember
        {
            get { return _displayMember; }
            set { _displayMember = value; }
        }
        public SimplePair() { }
        public SimplePair(int valueMember, string displayMember)
        {
            this._displayMember = displayMember;
            this._valueMember = valueMember;
        }
        public SimplePair(string valueMember, string displayMember)
        {
            this._strValue = valueMember;
            this._displayMember = displayMember; 
        }

    }
}
