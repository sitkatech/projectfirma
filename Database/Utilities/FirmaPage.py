import re
import os
import fileinput
from pathlib import Path

firma_page_type_id = None
firma_page_type_name = None
firma_page_type_display_name = None
firma_page_render_type_id = None
firma_page_content = None

def yes_or_no(question):
    reply = str(input(question + ' (y/n): ')).lower().strip()
    if not reply:
        return yes_or_no(question)
    if reply[0] == 'y':
        return True
    if reply[0] == 'n':
        return False
    else:
        return yes_or_no(question)


def add_field_definition_to_firma_page_type_file(item_to_add_comma_and_duplicate, new_item_string):
    with fileinput.FileInput(str(firma_page_type_sql_file_path), inplace=True) as firma_page_type_file:
        for line in firma_page_type_file:
            print(line.replace(item_to_add_comma_and_duplicate,
                               item_to_add_comma_and_duplicate + ",\n" + new_item_string), end="")


def get_next_release_script_number():
    release_script_number_list = []
    files = os.listdir(str(release_scripts_path))
    for file in files:
        search = re.search(r"(\d\d\d\d)", file)
        if (search):
            release_script_number_list.append(search.group(0))
    if any(release_script_number_list):
        release_script_number_list.sort()
        next_number = int(release_script_number_list[-1]) + 1
    else:
        next_number = int(input('Could not find any release scripts to guess the next number. '
                            'Please enter the release script number you want to use:'))
    return '%04d' % next_number


def get_firma_page_type_name():
    firma_page_type_name_input = input("Enter FirmaPageTypeName: ")
    if not firma_page_type_name_input.strip():
        print('FirmaPageTypeName cannot be empty')
        return get_firma_page_type_name()
    return firma_page_type_name_input


def get_firma_page_type_display_name():
    firma_page_type_display_name_input = input('Enter FirmaPageTypeDisplayName: ')
    if not firma_page_type_display_name_input.strip():
        print('FirmaPageTypeDisplayName cannot be empty')
        return get_firma_page_type_display_name()
    return firma_page_type_display_name_input


def get_firma_page_render_type_id():
    firma_page_render_type_id_input = int(input('Enter FirmaPageRenterTypeID (1 for Introductory Text, 2 for Page Content): '))
    if firma_page_render_type_id_input != 1 and firma_page_render_type_id_input != 2:
        print('FirmaPageTypeDisplayName must be 1 or 2')
        return get_firma_page_render_type_id()
    return firma_page_render_type_id_input


base_path = Path(__file__).parent
firma_page_type_sql_file_path = (base_path / "../LookupTables/dbo.FirmaPageType.sql").resolve()
release_scripts_path = (base_path / "../ReleaseScript").resolve()

with open(str(firma_page_type_sql_file_path)) as file:
    s = file.read()

matches = re.findall(r"(\((\d*),.*\))", s)
string_of_last_item = matches[-1][0]
number_of_last_item = matches[-1][1]
number_of_next_item = int(number_of_last_item) + 1
next_release_script_number = get_next_release_script_number()

firma_page_type_id = number_of_next_item
firma_page_type_name = get_firma_page_type_name()

firma_page_type_display_name = get_firma_page_type_display_name()

firma_page_render_type_id = get_firma_page_render_type_id()

firma_page_content = input('Enter FirmaPageContent, this is typically wrapped in a paragraph '
                           '(e.g. "<p>This page is for this purpose within the application</p>"): ')
print('The next release script number is:', next_release_script_number)
print('A release script will be generated with the following '
      'filename: "' + next_release_script_number + ' - {release script name}.sql"')
new_release_script_name = input('Enter a {release script name}: ')

number_of_unique_tenant_contents = input("Number of tenants that require different FirmaPageContent "
                                            "(e.g. PSP needs different content to replace "
                                            "Project with Near Term Action): ") or 0
list_of_tenant_dicts = []
for r in range(0, int(number_of_unique_tenant_contents)):
    print(str(r + 1), "of", number_of_unique_tenant_contents, "unique Firma Page Contents")
    tenant_dict = dict(TenantID=None, FirmaPageContent=None)
    tenant_dict["TenantID"] = int(input("TenantID: "))
    tenant_dict["FirmaPageContent"] = input("FirmaPagecontent: ")
    list_of_tenant_dicts.append(tenant_dict)

new_item_string = "(" + str(
    firma_page_type_id) + ", '" + firma_page_type_name + "', '" + firma_page_type_display_name + "', " + str(firma_page_render_type_id) + ")"
new_release_script_path = (
            str(release_scripts_path) + "/" + next_release_script_number + " - " + new_release_script_name + ".sql")

if yes_or_no("This will insert a new FirmaPageType after " + string_of_last_item + " with the id of " + str(
        number_of_next_item) + ". Is this okay? (answering no will cancel the script)") is False:
    exit()

if yes_or_no(
        "This will insert a new release script: \"" + new_release_script_path + "\". "
        "Is this okay? (answering no will cancel the script)") is False:
    exit()

# add the string to the dbo.FirmaPageType.sql file
add_field_definition_to_firma_page_type_file(string_of_last_item, new_item_string)
print("Added Firma Page to FirmaPageType file")

# add the new release script
file = open(new_release_script_path, "w")
# write the firma page type insert
file.write("INSERT [dbo].[FirmaPageType] ([FirmaPageTypeID], [FirmaPageTypeName], [FirmaPageTypeDisplayName], [FirmaPageRenderTypeID])"
           "\nVALUES\n" + new_item_string + "\n\n")

# write the firma page insert that will select for all tenants
file.write("INSERT [dbo].[FirmaPage] ([TenantID], [FirmaPageTypeID], [FirmaPageContent])"
           "SELECT TenantID,\n" + str(firma_page_type_id) + ",\n'" + firma_page_content + "'\n"
           "FROM [dbo].[Tenant]\n\n")

for tenant in list_of_tenant_dicts:
    file.write("UPDATE [dbo].[FirmaPage] "
               "SET FirmaPageContent = '" + str(tenant["FirmaPageContent"]) + "'\n"
               "WHERE TenantID = " + str(tenant["TenantID"]) + " and FirmaPageTypeID = " + str(firma_page_type_id) + "\n\n")
file.close()
print("Added new release script to project")
print("DONE")