import csv

# Number of data points
num_points = 100

# Generate x-values (e.g., from 1 to 10)
x_values = [i for i in range(1, num_points + 1)]

# Generate y-values as the reciprocal of x
y_values = [1 / x for x in x_values]

# Write to CSV file
with open('reciprocal_data.csv', 'w', newline='') as csvfile:
    fieldnames = ['x', 'y']
    writer = csv.DictWriter(csvfile, fieldnames=fieldnames)

    writer.writeheader()
    for i in range(num_points):
        writer.writerow({'x': x_values[i], 'y': y_values[i]})
