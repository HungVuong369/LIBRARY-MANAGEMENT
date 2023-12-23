using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    class UnitOfWork
    {
        #region Declare
        private ReaderRepository _ListReader;
        private AdultRepository _ListAdult;
        private ChildRepository _ListChild;
        private BookISBNRepository _ListBookISBN;
        private AuthorRepository _ListAuthor;
        private CategoryRepository _ListCategory;
        private BookTitleRepository _ListBookTitle;
        private BookRepository _ListBook;
        private ParameterRepository _ListParameter;
        private UserRepository _ListUser;
        private UserRoleRepository _ListUserRole;
        private FunctionRepository _ListFunction;
        private RoleFunctionRepository _ListRoleFunction;
        private UserInfoRepository _ListUserInfo;
        private RoleRepository _ListRole;
        private LoanSlipRepository _ListLoanSlip;
        private LoanDetailRepository _ListLoanDetail;
        private PublisherRepository _ListPublisher;
        private PenaltyReasonRepository _ListPenaltyReason;
        private LoanDetailHistoryRepository _ListLoanDetailHistory;
        private LoanHistoryRepository _ListLoanHistory;
        private TranslatorRepository _ListTranslator;
        private ProvinceRepository _ListProvince;
        #endregion

        #region Properties
        public ReaderRepository Readers
        {
            get
            {
                if (this._ListReader == null)
                    this._ListReader = new ReaderRepository();
                return this._ListReader;
            }
        }

        public AdultRepository Adults
        {
            get
            {
                if (this._ListAdult == null)
                    this._ListAdult = new AdultRepository();
                return this._ListAdult;
            }
        }

        public ChildRepository Childs
        {
            get
            {
                if (this._ListChild == null)
                    this._ListChild = new ChildRepository();
                return this._ListChild;
            }
        }

        public BookISBNRepository BookISBNs
        {
            get
            {
                if (this._ListBookISBN == null)
                    this._ListBookISBN = new BookISBNRepository();
                return this._ListBookISBN;
            }
        }

        public BookRepository Books
        {
            get
            {
                if (this._ListBook == null)
                    this._ListBook = new BookRepository();
                return this._ListBook;
            }
        }

        public AuthorRepository Authors
        {
            get
            {
                if (this._ListAuthor == null)
                    this._ListAuthor = new AuthorRepository();
                return this._ListAuthor;
            }
        }

        public CategoryRepository Categories
        {
            get
            {
                if (this._ListCategory == null)
                    this._ListCategory = new CategoryRepository();
                return this._ListCategory;
            }
        }

        public BookTitleRepository BookTitles
        {
            get
            {
                if (this._ListBookTitle == null)
                    this._ListBookTitle = new BookTitleRepository();
                return this._ListBookTitle;
            }
        }

        public UserRepository Users
        {
            get
            {
                if (this._ListUser == null)
                    this._ListUser = new UserRepository();
                return this._ListUser;
            }
        }

        public UserRoleRepository UserRoles
        {
            get
            {
                if (this._ListUserRole == null)
                    this._ListUserRole = new UserRoleRepository();
                return this._ListUserRole;
            }
        }

        public RoleRepository Roles
        {
            get
            {
                if (this._ListRole == null)
                    this._ListRole = new RoleRepository();
                return this._ListRole;
            }
        }

        public FunctionRepository Functions
        {
            get
            {
                if (this._ListFunction == null)
                    this._ListFunction = new FunctionRepository();
                return this._ListFunction;
            }
        }

        public RoleFunctionRepository RoleFunctions
        {
            get
            {
                if (this._ListRoleFunction == null)
                    this._ListRoleFunction = new RoleFunctionRepository();
                return this._ListRoleFunction;
            }
        }

        public UserInfoRepository UserInfos
        {
            get
            {
                if (this._ListUserInfo == null)
                    this._ListUserInfo = new UserInfoRepository();
                return this._ListUserInfo;
            }
        }

        public ParameterRepository Parameters
        {
            get
            {
                if (this._ListParameter == null)
                    this._ListParameter = new ParameterRepository();
                return this._ListParameter;
            }
        }

        public LoanSlipRepository Loanslips
        {
            get
            {
                if (this._ListLoanSlip == null)
                    this._ListLoanSlip = new LoanSlipRepository();
                return this._ListLoanSlip;
            }
        }

        public LoanDetailRepository LoanDetails
        {
            get
            {
                if (this._ListLoanDetail == null)
                    this._ListLoanDetail = new LoanDetailRepository();
                return this._ListLoanDetail;
            }
        }

        public PublisherRepository Publishers
        {
            get
            {
                if (this._ListPublisher == null)
                    this._ListPublisher = new PublisherRepository();
                return this._ListPublisher;
            }
        }

        public PenaltyReasonRepository PenaltyReasons
        {
            get
            {
                if (this._ListPenaltyReason == null)
                    this._ListPenaltyReason = new PenaltyReasonRepository();
                return this._ListPenaltyReason;
            }
        }

        public LoanDetailHistoryRepository LoanDetailHistories
        {
            get
            {
                if (this._ListLoanDetailHistory == null)
                    this._ListLoanDetailHistory = new LoanDetailHistoryRepository();
                return this._ListLoanDetailHistory;
            }
        }

        public LoanHistoryRepository LoanHistories
        {
            get
            {
                if (this._ListLoanHistory == null)
                    this._ListLoanHistory = new LoanHistoryRepository();
                return this._ListLoanHistory;
            }
        }

        public TranslatorRepository Translators
        {
            get
            {
                if (this._ListTranslator == null)
                    this._ListTranslator = new TranslatorRepository();
                return this._ListTranslator;
            }
        }

        public ProvinceRepository Provinces
        {
            get
            {
                if (this._ListProvince == null)
                    this._ListProvince = new ProvinceRepository();
                return this._ListProvince;
            }
        }
        #endregion

        public UnitOfWork() {
            #region Instantiation
            _ListReader = new ReaderRepository();

            _ListUserInfo = new UserInfoRepository();

            _ListAdult = new AdultRepository();
            _ListChild = new ChildRepository();
            _ListBookISBN = new BookISBNRepository();
            _ListAuthor = new AuthorRepository();
            _ListCategory = new CategoryRepository();
            _ListBookTitle = new BookTitleRepository();
            _ListBook = new BookRepository();
            _ListUser = new UserRepository();
            _ListUserRole = new UserRoleRepository();
            _ListRole = new RoleRepository();
            _ListFunction = new FunctionRepository();
            _ListRoleFunction = new RoleFunctionRepository();
            _ListParameter = new ParameterRepository();
            _ListLoanSlip = new LoanSlipRepository();
            _ListLoanDetail = new LoanDetailRepository();
            _ListPublisher = new PublisherRepository();
            _ListPenaltyReason = new PenaltyReasonRepository();
            _ListLoanDetailHistory = new LoanDetailHistoryRepository();
            _ListLoanHistory = new LoanHistoryRepository();
            _ListTranslator = new TranslatorRepository();
            _ListProvince = new ProvinceRepository();
            #endregion

            #region Load
            _ListCategory.Load();
            _ListReader.Load(true);

            _ListAdult.Load(true);

            _ListChild.Load(true);

            _ListBookTitle.Load();

            _ListBookISBN.Load();

            _ListBook.Load();

            _ListAuthor.Load();

            _ListUser.Load();

            _ListRole.Load();

            _ListFunction.Load(true);

            _ListRoleFunction.Load();

            _ListUserInfo.Load();

            _ListUserRole.Load();

            _ListParameter.Load();

            _ListLoanSlip.Load();

            _ListLoanDetail.Load();

            _ListPublisher.Load();

            _ListPenaltyReason.Load();

            _ListLoanHistory.Load();

            _ListLoanDetailHistory.Load();

            _ListTranslator.Load();

            _ListProvince.Load();
            #endregion
        }
    }
}