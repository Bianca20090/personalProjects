import os 
TASK_FILE="tasks.txt"

def load_task():
    tasks=[]
    if(os.path.exists(TASK_FILE)):
        with open(TASK_FILE,'r', encoding="utf-8") as f:
            for line in f:
                text, status=line.strip().rsplit("||",1)
                tasks.append({"text": text, "Done": status== "done"})
    return tasks


def save_tasks(tasks):
    with open(TASK_FILE, "w", encoding="utf-8") as f:
        for task in tasks:
            status="done" if task["Done"] else "not_done"
            f.write(f"{task['text']}||{status}\n")

def display_tasks(tasks):
    if not tasks:
        print(f"No tasks found")
    else:
        for i, task in enumerate(tasks,1):
            checkbox="✅" if task["Done"] else " "
            print(f"{i}. [{checkbox}] {task['text']}")
    print()

def task_manager():
    tasks=load_task()
    while True:
        print("\n*********Task List Manager*********")
        print("1. Add task")
        print("2. View Task")
        print("3. Mark Task as complete")
        print("4. Delete task")
        print("5. Exit")

        choise= input("Choose an option (1-5)").strip()

        match choise:
            case "1":
                text=input("Enter your task: ").strip()
                if text:
                    tasks.append({"text": text, "Done":False})
                    save_tasks(tasks)
                else:
                    print("Task cannot be empty")

            case "2":
                display_tasks(tasks)

            case "3":
                display_tasks(tasks)
                try: 
                    num=int(input("Enter task number"))
                    if 1<=num<=len(tasks):
                        tasks[num-1]["Done"]=True
                        save_tasks(tasks)
                        print("Task marked as Done")
                    else:
                        print("Invalid task number")

                except ValueError:
                    print("Please enter a number")


            case "4":
                            display_tasks(tasks)
                            try: 
                                num=int(input("Enter task number to delete:"))
                                if 1<=num<=len(tasks):
                                    removed=tasks.pop(num-1)
                                    save_tasks(tasks)
                                    print("Task removed!")
                                else:
                                    print("Invalid task number")
            
                            except ValueError:
                                print("Please enter a number")
            case "5":
                print("Exiting task Manager")
                break
            case _:
                print("Please choose a valid option")
            
                                
                        
task_manager()
