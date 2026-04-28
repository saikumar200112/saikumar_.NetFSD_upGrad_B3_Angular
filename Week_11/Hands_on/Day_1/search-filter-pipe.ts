import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'searchFilter',
})
export class SearchFilterPipe implements PipeTransform {
   public transform(contacts: any[], searchText: string): any[] {
    if (!contacts || !searchText) return contacts;
    
    searchText = searchText.toLowerCase();
    return contacts.filter(c => 
      c.name.toLowerCase().includes(searchText) || 
      c.email.toLowerCase().includes(searchText)
    );
  }
}
