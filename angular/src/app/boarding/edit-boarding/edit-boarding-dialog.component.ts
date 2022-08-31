import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  BoardingServiceProxy,
  BoardingDto
} from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-edit-boarding',
  templateUrl: './edit-boarding-dialog.component.html'
})

export class EditBoardingDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  boarding: BoardingDto = new BoardingDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _boardingService: BoardingServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._boardingService.get(this.id).subscribe((result: BoardingDto) => {
      this.boarding = result;
    });
  }

  save(): void {
    this.saving = true;

    this._boardingService.update(this.boarding).subscribe(
      () => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      },
      () => {
        this.saving = false;
      }
    );
  }
}
