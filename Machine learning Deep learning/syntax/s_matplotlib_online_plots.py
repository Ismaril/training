import random
import matplotlib.pyplot as plt
from itertools import count
from matplotlib.animation import FuncAnimation

a_values = []
b_values = []
x_values = []
y_values = []

index = count()


def animate(i):
    x_values.append(next(index))  # count returns generator sequence 1, 2, 3,... (till infinity?)
    y_values.append(random.randint(0, 5))

    a_values.append(next(index))  # count returns generator sequence 1, 2, 3,... (till infinity?)
    b_values.append(random.randint(0, 5))

    plt.cla()  # clear axes, Removes current plots from all axes
    plt.plot(a_values, b_values, c="r", label="line1")
    plt.plot(x_values, y_values, c="b", label="line2")
    plt.legend()


# gcf = get current figure
# interval = select how often to update plot, 1000 = 1 sec
anim = FuncAnimation(plt.gcf(), animate, interval=10)

plt.tight_layout()
plt.show()
