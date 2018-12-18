import { Component, OnInit, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { ActivatedRoute, Router } from '@angular/router';
import { MemberServiceProxy, PagedResultDtoOfIntegralDetail } from '@shared/service-proxies/member-center';
import { Member } from '@shared/entity/member-center/member';
import { IntegralDetail } from '@shared/entity/member-center';

@Component({
    moduleId: module.id,
    selector: 'member-detail',
    templateUrl: 'member-detail.component.html',
    styleUrls: ['member-detail.component.less']
})
export class MemberDetailComponent extends AppComponentBase implements OnInit {
    id: string;
    loading = false;
    member: Member = new Member();
    integralList: IntegralDetail[] = [];
    constructor(injector: Injector
        , private actRouter: ActivatedRoute
        , private router: Router
        , private memberService: MemberServiceProxy
    ) {
        super(injector);
        this.id = this.actRouter.snapshot.params['id'];
    }

    ngOnInit(): void {
        this.getMemberInfo();
        this.refreshData();
    }

    getMemberInfo() {
        if (this.id) {
            let params: any = {};
            params.id = this.id;
            this.memberService.getMemberByIdAsync(params).subscribe((result: Member) => {
                this.member = result;
            });
        }
    }


    refreshData() {
        if (this.id) {
            this.loading = true;
            let params: any = {};
            params.SkipCount = this.query.skipCount();
            params.MaxResultCount = this.query.pageSize;
            params.MemberId = this.id;
            this.memberService.getIntegralListByIdAsync(params).subscribe((result: PagedResultDtoOfIntegralDetail) => {
                this.loading = false;
                this.integralList = result.items;
                this.query.total = result.totalCount;
            })
        }
    }

    return() {
        this.router.navigate(['app/member/memberCenter']);
    }
}
