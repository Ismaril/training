
class SeparateCode:
    def __init__(self):
        self.number = 0

    def separator(self):
        self.number += 1
        return f"{self.number} {'-' * 50}"
