# random module
import random


# starting variables
text_source = open("C:/Users/Public/Documents/scrhangman.txt", "r")
secret_word = random.choice(text_source.readline().split()).lower()
correct_letters = []
guessed_letter = []
underscored_word = str("_" * len(secret_word))
len_secret_word = str(len(secret_word))
wrong_guess = 0
wrong_guess_limit = 12
game_ended = False
score_program = 0
score_player = 0
victory_emoji = ":-D"

# hangman text images
hangman = ['''

      ===''', '''
       |
      ===''', '''
       |
       |
      ===''', '''
       |
       |
       |
      ===''', '''
    ---+     
       |
       |
       |
      ===''', '''
   +---+
       |
       |
       |
      ===''', '''
   +---+
   O   |
       |
       |
      ===''', '''
   +---+
   O   |
   |   |
       |
      ===''', '''
   +---+
   O   |
  /|   |
       |
      ===''', '''
   +---+
   O   |
  /|\  |
       |
      ===''', '''
   +---+
   O   |
  /|\  |
  /    |
      ===''', '''
   +---+
   O   |
  /|\  |
  / \  |
      ===''']


# notify the player once his score == 10 and exit program
def score_ten():
    if score_player == 10 and score_program == 0:
        print("\n\nWell done, but don't be so confident with 12 tries on each round\n\n")
        input("Press enter to exit: ")
        exit()
    elif score_player == 10 and score_program == 1:
        print("\n\nThis game was meant to be won 10 : 0, feel bad about yoself\n\n")
        input("Press enter to exit: ")
        exit()
    elif score_player == 10 and score_program >= 2:
        print("\n\nThat feeling when you fuck up even the basic work,\n\n")
        input("Press enter to exit: ")
        exit()

# main loop
while wrong_guess < wrong_guess_limit:

    # Display of score, guesses, lenght of word, underscored secret word
    print("\n-------------------------------------------------------------------------------------------------")
    print(f"Your score: {score_player}\nProgram score: {score_program}\n")
    print(f"You got {wrong_guess_limit-wrong_guess} incorrect guesses left")
    print(f"The word is {len_secret_word} characters long\n")
    print(f"Guessed letters: {guessed_letter}\n")
    print(underscored_word + "\n")

    # Get input from user (letter)
    guess = input("Enter a letter: ").lower()

    # Check if letter already guessed, Check if letter correct
    if guess in guessed_letter:
        print("! Allready guessed letter !")
        continue
    if guess in secret_word:
        correct_letters.append(guess)
        guessed_letter.append(guess)
    else:
        wrong_guess += 1
        guessed_letter.append(guess)
        if wrong_guess <= wrong_guess_limit:
            print("\n-------------------------------------------------------------------------------------------------")
            print(hangman[wrong_guess - 1])

    # Replace underscore with correct letter
    for i in range(len(secret_word)):
        if secret_word[i] in correct_letters:
            underscored_word = underscored_word[:i] + secret_word[i] + underscored_word[i + 1:]

    # If user guessed the secret word correctly
    if underscored_word == secret_word:
        print("\n-------------------------------------------------------------------------------------------------")
        print("You won")
        print(f"Secret word was: {underscored_word}")
        print(victory_emoji)
        game_ended = True

        # If game ended, let the user decide whether to play again. If yes, set initial variables to zero & loop again.
        if game_ended:
            play_again = input("Wanna play again? (yes/no): ").lower()
            if play_again == "yes" or "y":
                text_source = open("C:/Users/Public/Documents/scrhangman.txt", "r")
                secret_word = (random.choice(text_source.readline().split())).lower()
                correct_letters = []
                guessed_letter = []
                len_secret_word = str(len(secret_word))
                underscored_word = str("_" * len(secret_word))
                wrong_guess = 0
                game_ended = False
                score_program = score_program
                score_player += 1
                score_ten()
            else:
                print("\n\nSee ya\n--END--\n\n")
                input("Press enter to exit: ")
                break

    # If user out of guesses, + same as comment above
    elif wrong_guess == wrong_guess_limit:
        print("\n-------------------------------------------------------------------------------------------------")
        print(f"You lost, secret word is: {secret_word}")
        game_ended = True
        if game_ended:
            play_again = input("Wanna play again? (yes/no): ").lower()
            if play_again == "yes" or "y":
                text_source = open("C:/Users/Public/Documents/scrhangman.txt", "r")
                secret_word = (random.choice(text_source.readline().split())).lower()
                correct_letters = []
                guessed_letter = []
                len_secret_word = str(len(secret_word))
                underscored_word = str("_" * len(secret_word))
                wrong_guess = 0
                game_ended = False
                score_program += 1
                score_player = score_player
                score_ten()
            else:
                print("\n\nGo cry to yo moma\n--END--\n\n")
                input("Press enter to exit: ")
                break






