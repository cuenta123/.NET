using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenericExample
{
    class SQLInsert : ISQL
    {
        StringBuilder sql;

        public void SQLStringConstructor(List<Generic> listGeneric)
        {
            if (listGeneric == null)
            {
                throw new ArgumentNullException("Lista de generica nula");
            }
            var table = listGeneric.ElementAt(0).type.Name;
           

            sql = new StringBuilder();
            sql.Append("Insert Into ");
            sql.Append(table);
            sql.Append(" (");

            SQLStringBuilderProperty(listGeneric);
            SQLStringBuilderValues(listGeneric);
        }

        private void SQLStringBuilderProperty( List<Generic> listGeneric)
        {
           
            listGeneric.ForEach(num => { listGeneric.ElementAt(0).type.GetProperties(); sql.Append(","); });    
            sql.Append(")");               
              
                }
        

        private void SQLStringBuilderValues(List<Generic> listGeneric)
        {

            int contador = 0;
            sql.Append(" Values (");

            List<PropertyInfo> listapropiedades = listGeneric.ElementAt(contador).type.GetProperties().ToList();
            foreach (var properties in listGeneric)
            {
                listGeneric.ForEach(num => { contador++; listapropiedades.ElementAt(contador).GetValue(contador); sql.Append(","); });
                contador = 0;
            }
                sql.Append(")");     
        }
    }
}
