# todo: unify the separator for all the files (AI and Python directories)


class SeparateText:
    """Separate text with a separator line."""

    def __init__(self):
        """Initialize the separator."""
        self.number = 0

    def separator(self):
        """
        Return a separator line.
        :return: string: a separator line"""
        self.number += 1
        return f"[{self.number}] {'-' * 79}\n"
