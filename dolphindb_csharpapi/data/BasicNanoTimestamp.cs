﻿using dolphindb.io;
using System;

namespace dolphindb.data
{
	public class BasicNanoTimestamp : BasicLong
	{
		private static string format = "yyyy.MM.dd HH:mm:ss.fffffff";

		public BasicNanoTimestamp(DateTime value) : base(Utils.countNanoseconds(value))
		{
		}

		public BasicNanoTimestamp(ExtendedDataInput @in) : base(@in)
		{
		}

		protected internal BasicNanoTimestamp(long value) : base(value)
		{
		}

		public override DATA_CATEGORY getDataCategory()
		{
				return DATA_CATEGORY.TEMPORAL;
		}

		public override DATA_TYPE getDataType()
		{
				return DATA_TYPE.DT_NANOTIMESTAMP;
		}

        public override object getObject()
        {
            return this.getValue();
        }
        public new DateTime getValue()
		{
				if (isNull())
				{
					return DateTime.MinValue;
				}
				else
				{
					return Utils.parseNanoTimestamp(base.getValue());
				}
		}
        public override object getTemporal()
        {
            return getValue();
        }

        public long getInternalValue()
        {
            return base.getValue();
        }

        public override string getString()
        {
            if (isNull())
            {
                return "";
            }
            else
            {
                return this.getValue().ToString(format);
            }
        }

        public override bool Equals(object o)
        {
            if (!(o is BasicMinute) || o == null)
            {
                return false;
            }
            else
            {
                return base.getValue() == ((BasicLong)o).getValue();
            }
        }
    }

}