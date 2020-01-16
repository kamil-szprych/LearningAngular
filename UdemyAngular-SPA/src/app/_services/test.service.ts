import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { saveAs } from 'file-saver';

@Injectable({
  providedIn: 'root'
})
export class TestService {
  private baseUrl = environment.apiUrl + 'test';
  constructor(private http: HttpClient) { }

  getFile() {
    this.http.get(this.baseUrl, {observe: 'response', responseType: 'blob' as 'json', params: {fileName: 'arkusz.xlsx'}})
    .subscribe((response: any) => {
      const contentDispositionHeader = response.headers.get('Content-Disposition').split(';')[1];
      const fileName = contentDispositionHeader.split('=')[1].trim().replace(/"/g, '');
      console.log(fileName);

      saveAs(response.body, fileName);
    });
  }

}
