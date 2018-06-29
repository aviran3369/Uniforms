using System;
using System.Collections.Generic;
using System.Text;

namespace Uniforms.Core.Entities.Fields
{
    public class EntityFieldType
    {
        private static List<EntityFieldType> _fieldTypes;

        private EntityFieldType(FieldType fieldType, int maxCellSize, int minCellSize, int defaultCellSize)
        {
            FieldType = fieldType;
            MaxCellSize = maxCellSize;
            MinCellSize = minCellSize;
            DefaultCellSize = defaultCellSize;
        }

        public FieldType FieldType { get; private set; }
        public int MinCellSize { get; private set; }
        public int MaxCellSize { get; private set; }
        public int DefaultCellSize { get; private set; }

        public static List<EntityFieldType> TypesList
        {
            get
            {
                if (_fieldTypes == null)
                    InitializeTypes();

                return _fieldTypes;
            }
        }

        private static void InitializeTypes()
        {
            _fieldTypes = new List<EntityFieldType>
            {
                new EntityFieldType(FieldType.TextBox, 3, 1, 1),
                new EntityFieldType(FieldType.TextArea, 3, 1, 1),
                new EntityFieldType(FieldType.RichText, 3, 3, 3),
                new EntityFieldType(FieldType.DropDown, 3, 1, 1),
                new EntityFieldType(FieldType.BooleanRadioButton, 1, 1, 1),
                new EntityFieldType(FieldType.Checkbox, 1, 1, 1),
                new EntityFieldType(FieldType.RadioButtonsGroup, 1, 3, 2),
                new EntityFieldType(FieldType.Email, 3, 1, 1),
                new EntityFieldType(FieldType.DateTime, 3, 1, 1),
                new EntityFieldType(FieldType.Hidden, 0, 0, 0),
                new EntityFieldType(FieldType.Number, 1, 1, 1),
                new EntityFieldType(FieldType.Lookup, 3, 1, 1),
                new EntityFieldType(FieldType.SimpleDynamicList, 3, 1, 1),
            };
        }
    }
}
