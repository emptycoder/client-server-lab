import { Component } from '@angular/core';
import { MatrixService } from '@services';
import { Output } from '@models';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
    public data: Output = new Output();
    public error: string;
    public result: string;

    constructor(private matrixService: MatrixService) {}

    public calculateMatrix(): void {
        this.matrixService.calculateMatrix(this.data).subscribe(
            (result) => {
                this.result = result;
                this.error = '';
            },
            (error) => {
                this.error = error;
                this.result = '';
                console.error(error);
            }
        );
    }
}
