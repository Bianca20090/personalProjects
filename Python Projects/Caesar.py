def encrypt(message, key):
    result=""
    for char in message:
        if char.isalpha():
            base=ord('A') if char.isupper() else ord('a')
            shifted=(ord(char)-base+key)% 26 + base
            result+=chr(shifted)
        else:
            result+=char
    return result

def decrypt(message, key):
    return encrypt(message, -key)


print("Secret message program:")
choice=input("Do ypu want E or D: ").strip().lower()

if choice=="e":
    text=input("Enter your messaje to encrypt: ")
    try:
        key=int(input("Enter a number between 1 and 26: "))
        encrypted=encrypt(text, key)
        print("Encrypted message: ")
        print(encrypted)
    except ValueError:
        print("Invalid key")

elif choice=='d':
    text=input("Enter your messaje to decrypt: ")
    try:
            key=int(input("Enter a number between 1 and 26: "))
            decrypted=decrypt(text, key)
            print("Encrypted message: ")
            print(decrypted)
    except ValueError:
            print("Invalid key")


else:
     print("Invalid choice!")
