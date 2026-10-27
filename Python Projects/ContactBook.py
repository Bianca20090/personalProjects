import csv
import os

FILE_NAME="contact.csv"

if not os.path.exists(FILE_NAME):
    with open(FILE_NAME,"w", newline="", encoding="utf-8") as f:
        writer=csv.writer(f)
        writer.writerow(["Name","Phone","Email"])
    

def add_contact():
    name=input("Name: ").strip()
    phone=input("Phone number: ").strip()
    email=input("Email: ").strip()

    with open(FILE_NAME,'r', encoding="utf-8") as f:
       reader= csv.DictReader(f)
       for row in reader:
           if row["Name"].lower()==name.lower():
               print("Contact name already exists!")
               return
           
    with open(FILE_NAME,'a', encoding="utf-8") as f:
        update=csv.writer(f)
        update.writerow([name, phone, email])
        print("New contact added!")



def view_contact():
    with open(FILE_NAME, 'r', encoding="utf-8") as f:
        contacts = csv.reader(f)
        rows = list(contacts)

        
        valid_rows = [row for row in rows[1:] if len(row) >= 3]

        if not valid_rows:
            print("No contacts found.\n")
            return

        print("Your contacts:\n")
        for row in valid_rows:
            print(f"{row[0]} | {row[1]} | {row[2]}")
        print("\n")

def search_contact():
    term=input("Enter the name to search: ").strip().lower()

    found=False
    with open(FILE_NAME,'r',encoding="utf-8") as f:
       reader= csv.DictReader(f)
       for row in reader:
           if term in row["Name"].lower():
               print(f"{row["Name"]} | {row["Phone"]}")
               found=True

    if not found:
        print("No matching contact found!")

def delete_contact():
    contact_to_delete = input("Please insert the name of the contact that you want to delete: ").strip().lower()
    
    rows = []
    contact_found = False

    
    with open(FILE_NAME, 'r', encoding="utf-8") as f:
        reader = csv.reader(f)
        rows = list(reader)

    if len(rows) <= 1:
        print("No contacts available to delete.\n")
        return

    header = rows[0]
    data_rows = rows[1:]
    
    new_data_rows = []
    
    
    for row in data_rows:
        if len(row) > 0 and row[0].strip().lower() == contact_to_delete:
            contact_found = True 
        else:
            new_data_rows.append(row)

    
    if contact_found:
        with open(FILE_NAME, 'w', newline="", encoding="utf-8") as f:
            writer = csv.writer(f)
            writer.writerow(header)       
            writer.writerows(new_data_rows) 
        print(f"Contact '{contact_to_delete}' has been successfully deleted!\n")
    else:
        print("The contact does not exist!\n")

def main():
    FILE_NAME="contact.csv"
    while True:
        print("1. Add a new contact.")
        print("2. View all contacts.")
        print("3. Search for a contact by name.")
        print("4. Delete a contact.")
        print("5. Exit")

        option=input("Please choose an option: ").strip()
        match option:
            case "1":
                add_contact()
            case "2":
                view_contact()
            case "3":
                search_contact()
            case "4":
                delete_contact()
            case "5":
                break
                

            

main()


