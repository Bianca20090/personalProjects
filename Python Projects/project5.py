emoji_map={
    "love": "❤️",
    "happy": "😊",
    "upset": "😦",
    "angry": "😠",
    "code": "🖥️"
}
user_message=input("Please enter your message: ")

updated_words=[]
for word in user_message.split():
    cleanWord=word.lower().strip(".,!?")
    emoji=emoji_map.get(cleanWord,"")
    if emoji:
        updated_words.append(f"{word} {emoji}")
    else:
        updated_words.append(f"{word}")

updated_message=" ".join(updated_words)
print("\nEnhanced message: \n")
print(f"{updated_message}")