import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from '@shared/paged-listing-component-base';
import {
  TripServiceProxy,
  TripDto,
  TripDtoPagedResultDto
} from '@shared/service-proxies/service-proxies';
import { CreateTripDialogComponent } from './create-trip/create-trip-dialog.component';
import { EditTripDialogComponent } from './edit-trip/edit-trip-dialog.component';

class PagedTripesRequestDto extends PagedRequestDto {
  keyword: string;
}

@Component({
  selector: 'app-trip',
  templateUrl: './trip.component.html',
  animations: [appModuleAnimation()]
})

export class TripComponent extends PagedListingComponentBase<TripDto> {
    tripes: TripDto[] = [];
    keyword = '';
  
    constructor(
      injector: Injector,
      private _tripesService: TripServiceProxy,
      private _modalService: BsModalService
    ) {
      super(injector);
    }
  
    list(
      request: PagedTripesRequestDto,
      pageNumber: number,
      finishedCallback: Function
    ): void {
      request.keyword = this.keyword;
  
      this._tripesService
        .getAll(request.keyword, request.skipCount, request.maxResultCount)
        .pipe(
          finalize(() => {
            finishedCallback();
          })
        )
        .subscribe((result: TripDtoPagedResultDto) => {
          this.tripes = result.items;
          this.showPaging(result, pageNumber);
        });
    }
  
    delete(trip: TripDto): void {
      abp.message.confirm(
        this.l('TripDeleteWarningMessage', trip.arrivalTime),
        undefined,
        (result: boolean) => {
          if (result) {
            this._tripesService
              .delete(trip.id)
              .pipe(
                finalize(() => {
                  abp.notify.success(this.l('SuccessfullyDeleted'));
                  this.refresh();
                })
              )
              .subscribe(() => {});
          }
        }
      );
    }
  
    createTrip(): void {
      this.showCreateOrEditTripDialog();
    }
  
    editTrip(trip: TripDto): void {
      this.showCreateOrEditTripDialog(trip.id);
    }
  
    showCreateOrEditTripDialog(id?: number): void {
      let createOrEditTripDialog: BsModalRef;
      if (!id) {
        createOrEditTripDialog = this._modalService.show(
          CreateTripDialogComponent,
          {
            class: 'modal-lg',
          }
        );
      } else {
        createOrEditTripDialog = this._modalService.show(
          EditTripDialogComponent,
          {
            class: 'modal-lg',
            initialState: {
              id: id,
            },
          }
        );
      }
  
      createOrEditTripDialog.content.onSave.subscribe(() => {
        this.refresh();
      });
    }
  }
  