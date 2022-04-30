class FiguresChess:
    def __init__(self, prompt, value, count):
        self.prompt = prompt
        self.value = value
        self.count = count


question_prompts = [
    "Enter pawns value (1 - 5) and count (1 - 8): ",
    "Enter kings value (1 - 5) and count (1 - 8): ",
    "Enter towers' value (1 - 5) and count (1 - 8): ",
]

questions = [
    FiguresChess(question_prompts[0], 1, 8),
    FiguresChess(question_prompts[1], 5, 1),
    FiguresChess(question_prompts[2], 3, 2)
]


def game(quests):
    score = 0
    for question in quests:
        answer = input(question.prompt)
        while len(answer) != 3:
            print("write down an answer in format: x y")
            answer = input(question.prompt)

        answer1 = answer.strip()[0]
        answer2 = answer.strip()[2]

        if answer1 == str(question.value) and answer2 == str(question.count):
            score += 2
        elif answer1 == str(question.value) or answer2 == str(question.count):
            score += 1

    print("You got " + str(score) + "/ " + str(len(quests)*2) + " right.")


game(questions)




