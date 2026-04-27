import { Student } from './student.model.js';
import { PASS_MARKS } from './constants.js';
import { formatName, calculateAverage } from './utils.js';
import * as StudentService from './student.service.js'; 


const studentList: Student[] = [
    { id: 1, name: 'Saikumar', marks: 85 },
    { id: 2, name: 'Jaswanth', marks: 95 },
    { id: 3, name: 'Satish', marks: 92 }
];

console.log(`--- Student Management Utility (Pass Marks: ${PASS_MARKS}) ---`);


studentList.forEach(s => {
    const formattedName = formatName(s.name);
    const grade = StudentService.getGrade(s.marks);
    const status = s.marks >= PASS_MARKS ? 'Passed' : 'Failed';

    console.log(`Student: ${formattedName} | Marks: ${s.marks} | Grade: ${grade} [${status}]`);
});


const average = calculateAverage(studentList);
const topper = StudentService.getTopper(studentList);

console.log('--- Summary ---');
console.log(`Average Marks: ${average.toFixed(2)}`);
console.log(`Topper: ${formatName(topper.name)} with ${topper.marks}%`);

