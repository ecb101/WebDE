using System;

namespace CommonLibrary
{
    public class CommonEnum
    {
        public enum ValueType
        {
            ALPHA_NUMERIC = 0,
            MONEY = 1,
            MEASUREMENT = 2,
            NUMERIC = 3,            
            ALL = 4
        }

        public enum MaskValueType
        {
            DATESHORT = 1,
            DATELONG = 2,
            DIMENSION = 3
        }
        
        public enum Status
        {
            NEW = 0,
            ACTIVE = 1,
            FOR_REVIEW = 2,
            COMPLETE = 3,
            PRODUCTION = 4
        }
        
        public enum PageState
        { 
            DEFAULT = 0,
            MODIFY = 1
        }

        public enum FormState
        { 
            NORMAL_STATE = 0,
            OPEN_STATE = 1,
            EDIT_STATE = 2,
            NEW_STATE = 3
        }

        public enum FormMode
        {
            DATA_ENTRY = 0,
            QUALITY_ASSURANCE = 1,
            DATA_ENTRY_TRAINER =2
        }

        public enum FormView
        {
            LIST_VIEW = 0,
            TREE_VIEW = 1
        }

        public enum UserType
        { 
            ADMIN = 0,
            USER = 1
        }

        public enum AddressType
        {
            PICKUP = 0,
            DELIVERY = 1,
            STOP_OFF = 2,
            SHIPPER_INVOICE = 3,
            SHIPPER_BOL = 4,
            SHIPPER_COM_INV = 5,
            CONSIGNEE_INVOICE = 6,
            CONSIGNEE_BOL = 7,
            CONSIGNEE_COM_INV = 8
        }
    }
}
