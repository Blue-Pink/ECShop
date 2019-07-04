using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
 

     public class Trade: Book
    {
         public System.Int32  TID
             {get;set;}
         public System.Int32  BID
             {get;set;}
         public System.Int32  MID
             {get;set;}
         public new System.Int32  BCount
             {get;set;}
       }
}
