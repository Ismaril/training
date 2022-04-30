import random
# module random

def greeting():
    # Initial welcome screen
    print("**************************\n"
          "** ROCK PAPER SCISSORS ***\n"
          "**************************\n"
          "\n\n")
    input("Press enter to continue: ")


def logic():
    # Variables
    rock = ["rock", "kamen", "kámen", "k", "r"]
    paper = ["paper", "papir", "papír", "pejpr", "p"]
    scissors = ["scissors", "nuzky", "nůžky", "n", "s"]
    exit_code = ["exit", "quit", "close", "vypnout", "zavřít", "zavrit"]
    tie = "It is a tie"
    lost = "You lost"
    won = "You won"
    fist = rock + paper + scissors
    score_user = 0
    score_machine = 0
    round_nr = 1

    while True:
        # Dashboard / display of score
        print(f"Round: {str(round_nr)}\n")
        print(f"User_score: {str(score_user)}")
        print(f"Machine_score: {str(score_machine)}\n")

        # Getting variables / input from competitors
        fist_user = input("Chose rock, paper, scissors or exit: ").lower()
        fist_machine = random.choice(fist)

        # Check if entered value is valid
        while fist_user not in fist and fist_user not in exit_code:
            print("\n!Enter rock, paper, scissors correctly or exit!\n")
            fist_user = input("Chose rock, paper, scissors or exit: ").lower()

        # Print output of battle & add score
        if fist_user in rock and fist_machine in rock:
            print(tie)
        elif fist_user in rock and fist_machine in paper:
            print(lost)
            score_machine += 1
        elif fist_user in rock and fist_machine in scissors:
            print(won)
            score_user += 1
        elif fist_user in paper and fist_machine in paper:
            print(tie)
        elif fist_user in paper and fist_machine in scissors:
            print(lost)
            score_machine += 1
        elif fist_user in paper and fist_machine in rock:
            print(won)
            score_user += 1
        elif fist_user in scissors and fist_machine in scissors:
            print(tie)
        elif fist_user in scissors and fist_machine in rock:
            print(lost)
            score_machine += 1
        elif fist_user in scissors and fist_machine in paper:
            print(won)
            score_user += 1

        # exit code if
        elif fist_user in exit_code:
            print("---END---\n\n\n")
            break

        round_nr += 1


def main():
    greeting()
    logic()


if __name__ == '__main__':
    main()

