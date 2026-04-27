import { Student } from './student.model.js';

export function getGrade(marks: number): string {
    if (marks >= 90) return 'A+';
    if (marks >= 75) return 'A';
    if (marks >= 60) return 'B';
    if (marks >= 40) return 'C';
    return 'F';
}

export function getTopper(students: Student[]): Student {
    
    return students.reduce((prev, current) => (prev.marks > current.marks) ? prev : current);
}
