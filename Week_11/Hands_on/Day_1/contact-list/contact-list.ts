import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { PhoneFormatPipe } from '../phone-format-pipe';
import { SearchFilterPipe } from '../search-filter-pipe';
import { StatusLabelPipe } from '../status-label-pipe';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-contact-list',
  imports: [FormsModule,CommonModule,PhoneFormatPipe,SearchFilterPipe,StatusLabelPipe],
  templateUrl: './contact-list.html',
  styleUrl: './contact-list.css',
})
export class ContactList {
      searchText: string = '';
      limit: number = 5;

  contacts = [
    { name: 'Saikumar', email: 'SAI123@example.com', phone: '1234567890', isActive: true },
    { name: 'Jaswanth', email: 'JASHU10@site.com', phone: '2345678901', isActive: false },
    { name: 'Satish', email: 'SATISH@web.com', phone: '3456789012', isActive: true },
    { name: 'Vinod', email: 'VINOD@mail.com', phone: '4567890123', isActive: true },
    { name: 'Vamsi', email: 'VAMSI@corp.com', phone: '5678901234', isActive: false },
    { name: 'Sunil', email: 'SUNIL@tech.com', phone: '6789012345', isActive: true },
    { name: 'Henry', email: 'HENRY@info.com', phone: '7890123456', isActive: false },
    { name: 'Dhoni', email: 'DHONI@net.com', phone: '8901234567', isActive: true },
    { name: 'Virat', email: 'VIRAT@auto.com', phone: '9012345678', isActive: false },
    { name: 'Rohith', email: 'ROHITH@design.com', phone: '0123456789', isActive: true }
  ];

  toggleStatus(contact: any) {
    contact.isActive = !contact.isActive;
  }

  toggleLimit() {
    this.limit = this.limit === 5 ? this.contacts.length : 5;
  }

}
