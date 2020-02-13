import re
import os
import fileinput
from pathlib import Path

field_definition_id = None
field_definition_name = None
field_definition_display_name = None
field_definition_default_definition = None
field_definition_data_value = None
field_definition_label = None


def yes_or_no(question):
    reply = str(input(question+' (y/n): ')).lower().strip()
    if not reply:
        return yes_or_no(question)
    if reply[0] == 'y':
        return True
    if reply[0] == 'n':
        return False
    else:
        return yes_or_no(question)


def add_field_definition_to_field_definition_file(item_to_add_comma_and_duplicate, new_item_string):
    with fileinput.FileInput(str(field_definition_sql_file_path), inplace=True) as field_definition_file:
        for line in field_definition_file:
            print(line.replace(item_to_add_comma_and_duplicate, item_to_add_comma_and_duplicate + ",\n" + new_item_string), end="")


def get_next_release_script_number():
    release_script_number_list = []
    files = os.listdir(str(release_scripts_path))
    for file in files:
        search = re.search(r"(\d\d\d\d)", file)
        if(search):
            release_script_number_list.append(search.group(0))
    release_script_number_list.sort()
    next_number = int(release_script_number_list[-1]) + 1
    return '%04d' % next_number


def get_field_definition_name():
    field_definition_name_input = input("Enter FieldDefinitionName: ")
    if not field_definition_name_input.strip():
        print('FieldDefinitionName cannot be empty')
        return get_field_definition_name()
    return field_definition_name_input


def get_field_definition_display_name():
    field_definition_display_name_input = input('Enter FieldDefinitionDisplayName: ')
    if not field_definition_display_name_input.strip():
        print('FieldDefinitionDisplayName cannot be empty')
        return get_field_definition_display_name()
    return field_definition_display_name_input


base_path = Path(__file__).parent
field_definition_sql_file_path = (base_path / "../../../LookupTables/dbo.FieldDefinition.sql").resolve()
release_scripts_path = (base_path / "../../../ReleaseScript").resolve()

with open(str(field_definition_sql_file_path)) as file:
    s = file.read()

matches = re.findall(r"(\((\d*),.*\))", s)
string_of_last_item = matches[-1][0]
number_of_last_item = matches[-1][1]
number_of_next_item = int(number_of_last_item) + 1;
next_release_script_number = get_next_release_script_number()


field_definition_id = number_of_next_item
field_definition_name = get_field_definition_name()

field_definition_display_name = get_field_definition_display_name()
field_definition_default_definition = input('Enter DefaultDefinition: ')
print('The next release script number is:', next_release_script_number)
print('A release script will be generated with the following filename: "' + next_release_script_number + ' - {release script name}.sql"')
new_release_script_name = input('Enter a {release script name}: ')

number_of_unique_tenant_definitions = input("Number of tenants that require different definition "
                                                "labels are values (e.g. PSP needs a different definition to replace "
                                                "Project with Near Term Action): ") or 0
list_of_tenant_dicts = []
for r in range(0, int(number_of_unique_tenant_definitions)):
    print(str(r + 1), "of", number_of_unique_tenant_definitions, "unique tenant definitions")
    tenant_dict = dict(TenantID=None, FieldDefinitionDataValue=None, FieldDefinitionLabel=None)
    tenant_dict["TenantID"] = int(input("TenantID: "))
    tenant_dict["FieldDefinitionLabel"] = input("FieldDefinitionLabel: ")
    tenant_dict["FieldDefinitionDataValue"] = input("FieldDefinitionDataValue: ")
    list_of_tenant_dicts.append(tenant_dict)


new_item_string = "(" + str(field_definition_id) + ", N'" + field_definition_name + "', N'" + field_definition_display_name + "')"
new_release_script_path = (str(release_scripts_path) + "/" + next_release_script_number + " - " + new_release_script_name + ".sql")

if yes_or_no("This will insert a new FieldDefinition after " + string_of_last_item + " with the id of " + str(number_of_next_item) + ". Is this okay? (answering no will cancel the script)") is False:
    exit()

if yes_or_no("This will insert a new release script: \"" + new_release_script_path + "\". Is this okay? (answering no will cancel the script)") is False:
    exit()

# add the string to the dbo.FieldDefinition.sql file
add_field_definition_to_field_definition_file(string_of_last_item, new_item_string)
print("Added field definition to FieldDefinition file")

# add the new release script
file = open(new_release_script_path, "w")
file.write("INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName])"
           "\nVALUES\n" + new_item_string + "\n\n")
file.write("INSERT [dbo].[FieldDefinitionDefault] ([FieldDefinitionID], [DefaultDefinition])"
           "\nVALUES\n(" + str(field_definition_id) + ", N'" + field_definition_default_definition + "')\n\n")
for tenant in list_of_tenant_dicts:
    file.write("INSERT into [dbo].[FieldDefinitionData] "
               "([TenantID], [FieldDefinitionID], [FieldDefinitionDataValue], [FieldDefinitionLabel])"
               "\nVALUES\n(" + str(tenant["TenantID"]) + ", " + str(field_definition_id) + ", N'" + tenant["FieldDefinitionDataValue"] + "', N'" + tenant["FieldDefinitionLabel"] + "')\n\n")
file.close()
print("Added new release script to project")
print("DONE")