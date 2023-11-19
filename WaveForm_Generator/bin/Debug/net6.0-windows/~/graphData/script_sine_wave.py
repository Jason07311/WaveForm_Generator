import csv
import math
import os

# Function to generate sine wave data
def generate_sine_wave(num_points, amplitude, frequency, sampling_rate):
    time_values = [i / sampling_rate for i in range(num_points)]
    voltage_values = [amplitude * math.sin(2 * math.pi * frequency * t) for t in time_values]
    return time_values, voltage_values

# Parameters for the sine wave
num_points = 5000  # Adjust the number of points as needed
amplitude = 500.0
frequency = 10.0  # Adjust the frequency as needed
sampling_rate = 50.0  # Adjust the sampling rate as needed

# Generate sine wave data
time_data, voltage_data = generate_sine_wave(num_points, amplitude, frequency, sampling_rate)

# Create a unique CSV filename
csv_filename = 'sine_wave_data.csv'
file_counter = 1

while os.path.exists(csv_filename):
    file_counter += 1
    csv_filename = f'sine_wave_data_{file_counter}.csv'

with open(csv_filename, 'w', newline='') as csv_file:
    csv_writer = csv.writer(csv_file)
    csv_writer.writerow(['Time', 'Voltage'])
    for time, voltage in zip(time_data, voltage_data):
        csv_writer.writerow([time, voltage])

print(f"CSV file '{csv_filename}' created successfully.")