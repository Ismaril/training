import random
import sys

# 28.10.2021, refactored on 24.05.2022

SOURCE_OF_WORDS = "support files/source_text_hangman.txt"
SEPARATOR = "\n" + "-" * 50
VICTORY_EMOJI = ":-D"
GUESS_LIMIT = 12
MAX_SCORE = 10
TEXT_SOURCE = open(SOURCE_OF_WORDS, "r")


class Hangman:
    def __init__(self):
        self.text_source = TEXT_SOURCE.readline().split()
        self.secret_word = random.choice(self.text_source).lower()
        self.underscored_word = str("_" * len(self.secret_word))
        self.len_secret_word = len(self.secret_word)
        self.wrong_guess = 0
        self.score_program = 0
        self.score_player = 0
        self.correct_letters = []
        self.guessed_letter = []
        self.game_ended = False
        self.guess = None

    # hangman text images
    text_images = ['''
    
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

    def total_player_victory(self):
        """Player reached multiple victories"""
        if self.score_player == MAX_SCORE and self.score_program == 0:
            print("\n\nWell done, but don't be so confident with 12 tries on each round\n\n")
        elif self.score_player == MAX_SCORE and self.score_program == 1:
            print("\n\nThis game was meant to be won 10 : 0, feel bad about yoself\n\n")
        elif self.score_player == MAX_SCORE and self.score_program >= 2:
            print("\n\nThat feeling when you fuck up even the basic work,\n\n")

    def total_player_defeat(self):
        """Machine reached multiple victories"""
        if self.score_program == MAX_SCORE:
            print("\n\nGo cry to yo moma\n--END--\n\n")

    def player_victory(self):
        """If user guessed the secret word correctly"""
        if self.underscored_word == self.secret_word:
            print(SEPARATOR)
            print(f"You won.\nSecret word was: {self.underscored_word}")
            print(VICTORY_EMOJI)
            self.game_ended = True
            self.score_player += 1

    def player_defeat(self):
        """If user out of guesses"""
        if self.wrong_guess == GUESS_LIMIT:
            print(SEPARATOR)
            print(f"You lost.\nSecret word is: {self.secret_word}")
            self.game_ended = True
            self.score_program += 1

    def restart_game(self):
        if self.game_ended:
            play_again = input("Wanna play again? (yes/no): ").lower()
            if play_again == "no":
                print("See ya")
                input("Pres enter to exit: ")
                sys.exit()
            elif play_again == "yes":
                self.secret_word = random.choice(self.text_source).lower()
                self.underscored_word = str("_" * len(self.secret_word))
                self.len_secret_word = len(self.secret_word)
                self.wrong_guess = 0
                self.correct_letters = []
                self.guessed_letter = []
                self.game_ended = False
                TEXT_SOURCE.close()
            elif play_again not in ["yes", "no"]:
                print("Chose again: ")
                self.restart_game()

    def display_score(self):
        """Display of score, guesses, length of word, underscored secret word"""
        print(f"Your score: {self.score_player}\nProgram score: {self.score_program}\n")
        print(f"You got {GUESS_LIMIT - self.wrong_guess} incorrect guesses left")
        print(f"The word is {self.len_secret_word} characters long\n")
        print(f"Guessed letters: {self.guessed_letter}\n")
        print(self.underscored_word + "\n")

    def get_input_from_user(self):
        """Get input from user (letter)"""
        self.guess = input("Enter a letter: ").lower()

    def check_correct_letter(self):
        """Check if letter already guessed, Check if letter correct"""
        if self.guess in self.guessed_letter:
            print("! Already guessed letter !")
        elif self.guess in self.secret_word:
            self.correct_letters.append(self.guess)
            self.guessed_letter.append(self.guess)
        else:
            self.wrong_guess += 1
            self.guessed_letter.append(self.guess)
            if self.wrong_guess <= GUESS_LIMIT:
                print(SEPARATOR)
                print(self.text_images[self.wrong_guess - 1])

    def replace_underscores(self):
        """Replace underscore with correct letter"""
        for i in range(len(self.secret_word)):
            if self.secret_word[i] in self.correct_letters:
                self.underscored_word = self.underscored_word[:i] \
                                        + self.secret_word[i] \
                                        + self.underscored_word[i + 1:]

    def loop(self):
        global GUESS_LIMIT
        while self.wrong_guess < GUESS_LIMIT:
            print(SEPARATOR)
            self.display_score()
            self.get_input_from_user()
            self.check_correct_letter()
            self.replace_underscores()
            self.player_victory()
            self.player_defeat()
            self.total_player_victory()
            self.total_player_defeat()
            self.restart_game()


if __name__ == '__main__':
    h = Hangman()
    h.loop()
