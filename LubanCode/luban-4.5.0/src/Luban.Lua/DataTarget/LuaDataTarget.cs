// Copyright 2025 Code Philosophy
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Text;
using Luban.CodeFormat;
using Luban.Datas;
using Luban.DataTarget;
using Luban.Defs;
using Luban.Lua.DataVisitors;
using Luban.TemplateExtensions;
using Luban.Tmpl;
using Luban.Utils;
using Scriban;
using Scriban.Runtime;

namespace Luban.Lua.DataTarget;

[DataTarget("lua")]
public class LuaDataTarget : DataTargetBase
{
    public void ExportTableSingleton(DefTable t, Record record, StringBuilder result)
    {
        result.Append("return ").AppendLine();
        result.Append(record.Data.Apply(ToLuaLiteralVisitor.Ins));
    }

    public void ExportTableMap(DefTable t, List<Record> records, StringBuilder s)
    {
        s.Append("return").AppendLine();
        s.Append('{').AppendLine();
        foreach (Record r in records)
        {
            DBean d = r.Data;
            string keyStr = d.GetField(t.Index).Apply(ToLuaLiteralVisitor.Ins);
            if (!keyStr.StartsWith("[", StringComparison.Ordinal))
            {
                s.Append($"[{keyStr}] = ");
            }
            else
            {
                s.Append($"[ {keyStr} ] = ");
            }
            s.Append(d.Apply(ToLuaLiteralVisitor.Ins));
            s.Append(',').AppendLine();
        }
        s.Append('}');
    }

    public void ExportTableList(DefTable t, List<Record> records, StringBuilder s)
    {
        s.Append("return").AppendLine();
        s.Append('{').AppendLine();
        foreach (Record r in records)
        {
            DBean d = r.Data;
            s.Append(d.Apply(ToLuaLiteralVisitor.Ins));
            s.Append(',').AppendLine();
        }
        s.Append('}');
    }

    protected override string DefaultOutputFileExt => "lua";

    public override OutputFile ExportTable(DefTable table, List<Record> records)
    {
        var ss = new StringBuilder();
        if (table.IsMapTable)
        {
            ExportTableMap(table, records, ss);
        }
        else if (table.IsSingletonTable)
        {
            ExportTableSingleton(table, records[0], ss);
        }
        else
        {
            ExportTableList(table, records, ss);
        }
        GenerateDataBySchema("lua-data","schema", table, records, ss);
        return CreateOutputFile($"{table.OutputDataFile}.{OutputFileExt}", ss.ToString());
    }

    private void GenerateDataBySchema(string templateDir, string name, DefTable t, List<Record> records, StringBuilder s)
    {
        if (TemplateManager.Ins.TryGetTemplate($"{templateDir}/{name}", out var template))
        {
            List<dynamic> listDefault = new List<dynamic>();
            var map = CreateTableDefaultValue(t, records);
            foreach (var v in map)
            {
                listDefault.Add(new { name = v.Key, value = v.Value });
            }

            ToLuaCustomVisitor.Ins.InitHierarchyCount();
            List<dynamic> listTable = new List<dynamic>();
            foreach (Record r in records)
            {
                DBean d = r.Data;
                int index = 0;
                List<dynamic> listChildTable = new List<dynamic>();
                foreach (var f in d.Fields)
                {
                    var defField = (DefField)d.ImplType.HierarchyFields[index++];
                    string keyChildStr = defField.Name;
                    listChildTable.Add(new { name = keyChildStr, value = f.Apply(ToLuaCustomVisitor.Ins) });
                }
                string keyStr = d.GetField(t.Index).Apply(ToLuaCustomVisitor.Ins);
                listTable.Add(new { name = $"[{keyStr}]", value = listChildTable });
            }


            var ctx = new TemplateContext()
            {
                LoopLimit = 0,
                NewLine = "\n",
            };
            ctx.PushGlobal(new ContextTemplateExtension());
            ctx.PushGlobal(new TypeTemplateExtension());
            var extraEnvs = new ScriptObject
            {
                { "__default", listDefault},
                { "__tables", listTable },
                { "__file", t.FullName },
                { "__not_equal_default", (Func<string, string, Dictionary<string, string>, bool>)( (str1, str2, dict) =>
                    {
                        return IsNotEqualDefault(str1,str2,dict,out var result);
                    })},
            };
            ctx.PushGlobal(extraEnvs);
            s.Append(template.Render(ctx));

        }
    }

    private Dictionary<string,string> CreateTableDefaultValue(DefTable t, List<Record> records)
    {
        var map = new Dictionary<string, string>();
        foreach (Record r in records)
        {
            DBean d = r.Data;
            int index = 0;
            foreach (var f in d.Fields)
            {
                var defField = (DefField)d.ImplType.HierarchyFields[index++];
                string keyStr = defField.Name;
                if (!map.ContainsKey(keyStr))
                {
                    var value = f.Apply(ToLuaLiteralVisitor.Ins);
                    var value_type = f.TypeName;
                    if (int.TryParse(value, out var int_result))
                    {
                        map.Add(keyStr, default(int).ToString());
                    }
                    else if (float.TryParse(value, out var float_result))
                    {
                        map.Add(keyStr, default(float).ToString());
                    }
                    else if (bool.TryParse(value, out var bool_result))
                    {
                        map.Add(keyStr, default(bool).ToString());
                    }
                    else if (value_type == "string")
                    {
                        map.Add(keyStr, "\"\"");
                    }
                    else
                    {
                        map.Add(keyStr, "{}");
                    }
                }
            }
        }
        return map;
    }

    public static bool IsNotEqualDefault(string k, string v, Dictionary<string, string> map, out bool result)
    {
        if (map.ContainsKey(k))
        {
            if (map[k] == v)
            {
                result= false;
                return result;
            }
        }
        result= true;
        return result;
    }
}
