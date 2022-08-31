import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from '@shared/paged-listing-component-base';
import {
  BoardingServiceProxy,
  BoardingDto,
  BoardingDtoPagedResultDto
} from '@shared/service-proxies/service-proxies';
import { CreateBoardingDialogComponent } from './create-boarding/create-boarding-dialog.component';
import { EditBoardingDialogComponent } from './edit-boarding/edit-boarding-dialog.component';

class PagedBoardingesRequestDto extends PagedRequestDto {
  keyword: string;
}

@Component({
  selector: 'app-boarding',
  templateUrl: './boarding.component.html',
  animations: [appModuleAnimation()]
})

export class BoardingComponent extends PagedListingComponentBase<BoardingDto> {
    boardinges: BoardingDto[] = [];
    keyword = '';
  
    constructor(
      injector: Injector,
      private _boardingesService: BoardingServiceProxy,
      private _modalService: BsModalService
    ) {
      super(injector);
    }
  
    list(
      request: PagedBoardingesRequestDto,
      pageNumber: number,
      finishedCallback: Function
    ): void {
      request.keyword = this.keyword;
  
      this._boardingesService
        .getAll(request.keyword, request.skipCount, request.maxResultCount)
        .pipe(
          finalize(() => {
            finishedCallback();
          })
        )
        .subscribe((result: BoardingDtoPagedResultDto) => {
          this.boardinges = result.items;
          this.showPaging(result, pageNumber);
        });
    }
  
    delete(boarding: BoardingDto): void {
      abp.message.confirm(
        this.l('BoardingDeleteWarningMessage', boarding.studentStaffNumber),
        undefined,
        (result: boolean) => {
          if (result) {
            this._boardingesService
              .delete(boarding.id)
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
  
    createBoarding(): void {
      this.showCreateOrEditBoardingDialog();
    }
  
    editBoarding(boarding: BoardingDto): void {
      this.showCreateOrEditBoardingDialog(boarding.id);
    }
  
    showCreateOrEditBoardingDialog(id?: number): void {
      let createOrEditBoardingDialog: BsModalRef;
      if (!id) {
        createOrEditBoardingDialog = this._modalService.show(
          CreateBoardingDialogComponent,
          {
            class: 'modal-lg',
          }
        );
      } else {
        createOrEditBoardingDialog = this._modalService.show(
          EditBoardingDialogComponent,
          {
            class: 'modal-lg',
            initialState: {
              id: id,
            },
          }
        );
      }
  
      createOrEditBoardingDialog.content.onSave.subscribe(() => {
        this.refresh();
      });
    }
  }
  