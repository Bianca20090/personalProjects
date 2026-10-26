# Bill splitter
import datetime
def get_float(prompt):
    while True:
        try: 
            return float(input(prompt))
        except ValueError:
            print("Please enter a valid number.")
        finally:
            print("")

number_of_people = int(input("How many people are in the group? "))
names = []
for i in range(number_of_people):
    name = input(f"Enter the name of person #{i+1}: ").strip()
    names.append(name)

total_bill = get_float("Enter the bill amount in numbers only: ")

def generate_receipt(total_bill, number_of_people, names):
    share = round(total_bill / number_of_people, 2)
    
    
    lines = [
        "\n" + "*" * 40,
        f"Total bill: {total_bill}",
        f"Total per person: {share}",
        "*" * 40
    ]
    
    for name in names:
        lines.append(f"{name} owes {share}.")
        
    lines.append("*" * 40)
    
    
    receipt_text = "\n".join(lines)
    currentDate=datetime.date.today().isoformat()
    receipt_text+=f"\nDate: {currentDate}"
    print(receipt_text)
    return receipt_text


receipt_content = generate_receipt(total_bill, number_of_people, names)


save = input("Do you want to keep the receipt? (y/n): ").strip().lower()

if save == 'y':
    
    filename = f"receipt_{number_of_people}_people.txt"
    with open(filename, "w", encoding="utf-8") as f:
        f.write(receipt_content)
    print("File saved successfully!")